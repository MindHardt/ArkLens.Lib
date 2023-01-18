using ArkLens.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;

namespace ArkLens.Extensions;

/// <summary>
/// Represents an SVG file with character sheet. It is expected to catch all changes
/// of inner <see cref="Models.CharacterDraft"/> object and update its data.
/// </summary>
public class CharacterSheetSvg
{
	private static readonly ConditionalWeakTable<CharacterDraft, CharacterSheetSvg> s_svgs = new();
	private readonly XmlDocument _document = new();

	public CharacterDraft CharacterDraft { get; }
	public string Content => _document.OuterXml;

	private CharacterSheetSvg(CharacterDraft characterDraft, string rawSvg)
	{
		CharacterDraft = characterDraft;
		_document.LoadXml(rawSvg);
	}

	/// <summary>
	/// Tries to get <see cref="CharacterSheetSvg"/> object associated with <paramref name="draft"/>
	/// or creates a new one and saves it.
	/// </summary>
	/// <param name="draft"></param>
	/// <param name="rawSvg">Raw SVG file with placeholder values.</param>
	/// <returns></returns>
	public static CharacterSheetSvg GetOrCreate(CharacterDraft draft, string rawSvg)
	{
		if (s_svgs.TryGetValue(draft, out var svg))
		{
			return svg;
		}
		else
		{
			svg = new CharacterSheetSvg(draft, rawSvg);
			s_svgs.Add(draft, svg);
			return svg;
		}
	}


	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
