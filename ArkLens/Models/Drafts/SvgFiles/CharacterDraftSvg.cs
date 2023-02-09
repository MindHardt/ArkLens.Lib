using ArkLens.Core;
using ArkLens.Models.Alignments;
using ArkLens.Properties;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ArkLens.Models.Drafts.SvgFiles;

public partial class CharacterDraftSvg : IDynamicSvg<CharacterDraft>
{
    private readonly Dictionary<string, XmlNode> _lookup = new();
    private readonly Dictionary<string, Action> _actions = new();

    public CharacterDraftSvg(CharacterDraft value, string? svg = default)
    {
        svg ??= Encoding.UTF8.GetString(Resources.CharacterFront);
        Xml.LoadXml(svg);
        Value = value;

        FillLookup();
        MapHeader();

        Value.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName is null) return;

            _actions.GetValueOrDefault(e.PropertyName)?.Invoke();
        };
    }

    public XmlDocument Xml { get; } = new();

    public CharacterDraft Value { get; }

    private void FillLookup()
    {
        var nodes = Xml.SelectNodes(".//text[starts-with(text(), `${`) and ends-with(text(), `}`)]");

        ArgumentNullException.ThrowIfNull(nodes);

        for(int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i]!;

            Match regexMatch = NameRegex().Match(node.InnerText);
            string name = regexMatch.Groups[NameGroup].Value.ToUpper();

            _lookup[name] = node;
        }
    }

    private void MapHeader()
    {
        string name = nameof(Value.Name);
        AddFillAction(name, d => d.Name);

        string race = nameof(Value.Race);
        AddFillAction(race, d => d.Race.Name);

        string alignment = nameof(Value.Alignment);
        AddFillAction(alignment, d => d.Alignment.Name);

    }

    /// <summary>
    /// Adds action bind so that when <see cref="Value"/> changes <paramref name="propName"/>
    /// property, corresponding <see cref="Xml"/> node is updated.
    /// </summary>
    /// <param name="propName"></param>
    /// <param name="datasource"></param>
    private void AddFillAction(string propName, Func<CharacterDraft, string?> datasource)
    {
        _actions[propName] = () =>
        {
            _lookup[propName.ToUpper()].InnerText = datasource(Value) ?? string.Empty;
        };
    }

    private const string NameGroup = "NAME";
    [GeneratedRegex($"\\${{(?<{NameGroup}>.*?)}}")]
    private static partial Regex NameRegex();
}
