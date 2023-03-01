using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;

namespace ArkLens.Models.DynamicSvg;

/// <summary>
/// Allows to create a dynamic svg file for <typeparamref name="T"/> type,
/// it is expected to update itself on change of <see cref="Value"/>.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract partial class DynamicSvg<T>
	where T : class, INotifyPropertyChanged
{
	private const string NameGroup = "NAME";
	private const string RegExpText = $"\\${{(?<{NameGroup}>.*?)}}";

	[GeneratedRegex(RegExpText)]
	private static partial Regex NameRegex();

	protected readonly Dictionary<string, List<XmlNode>> _nodes = new();
	protected readonly Dictionary<string, Action> _actions = new();

	private static readonly ConditionalWeakTable<T, DynamicSvg<T>> s_cache = new();

	/// <summary>
	/// Gets cached <see cref="DynamicSvg{T}"/> or creates and caches new one.
	/// </summary>
	/// <param name="key"></param>
	/// <param name="factory"></param>
	/// <returns></returns>
	public static DynamicSvg<T> GetOrCreate(T key, Func<T, DynamicSvg<T>> factory)
	{
		if (s_cache.TryGetValue(key, out var value) is false)
		{
			value = factory(key);
			s_cache.Add(key, value);
		}

		return value;
	}

	/// <summary>
	/// The XML document containing SVG with all values set.
	/// </summary>
	public XmlDocument Xml { get; } = new();
	/// <summary>
	/// The resulting svg as <see cref="string"/>. It is a shortcut for <see cref="Xml"/>.OuterXml.
	/// </summary>
	public string Result => Xml.OuterXml;
	/// <summary>
	/// The <typeparamref name="T"/> being represented.
	/// </summary>
	public T Value { get; }

	/// <summary>
	/// The default constructor that fills all properties and 
	/// adds <see cref="INotifyPropertyChanged.PropertyChanged"/> callbacks.
	/// </summary>
	/// <param name="value"></param>
	/// <param name="svg"></param>
	public DynamicSvg(T value, string svg)
	{
		Value = value;
		Xml.LoadXml(svg);

		FillLookup();
		MapActions();

		Value.PropertyChanged += (_, e) =>
		{
			if (e.PropertyName is null) return;

			_actions.GetValueOrDefault(e.PropertyName)?.Invoke();
		};
	}

	/// <summary>
	/// Fills <see cref="_nodes"/> with all dummy values found in <see cref="Xml"/>.
	/// By default dummy values are formatted like "${NAME}".
	/// </summary>
	protected virtual void FillLookup()
	{
		// TODO: Implement proper search via X-Path
		List<XmlNode> nodes = new();
		RecursiveAddNodes(Xml, nodes);

		foreach (var node in nodes)
		{
			Match regexMatch = NameRegex().Match(node.InnerText);
			string name = regexMatch.Groups[NameGroup].Value.ToUpper();

			if (_nodes.TryGetValue(name, out var list))
			{
				list.Add(node);
			}
			else
			{
				_nodes.Add(name, new List<XmlNode> { node });
			}
			node.InnerText = string.Empty;
		}
	}
	private void RecursiveAddNodes(XmlNode node, List<XmlNode> list)
	{
		if (node.HasChildNodes)
		{
			foreach (var child in node.ChildNodes.OfType<XmlNode>())
			{
				RecursiveAddNodes(child, list);
			}
		}
		else if (NameRegex().IsMatch(node.InnerText))
		{
			list.Add(node);
		}
	}

	/// <summary>
	/// Fills <see cref="_actions"/> so that all meaningful triggers of <see cref="Value"/>'s
	/// <see cref="INotifyPropertyChanged.PropertyChanged"/> are being projected.
	/// </summary>
	protected abstract void MapActions();

	/// <summary>
	/// Adds action bind so that when <see cref="Value"/> changes <paramref name="propName"/>
	/// property, corresponding <see cref="Xml"/> node is updated.
	/// </summary>
	/// <param name="propName"></param>
	/// <param name="datasource"></param>
	protected virtual void AddFillAction(string propName, Func<T, string?> datasource)
	{
		_actions[propName] = () =>
		{
			if (_nodes.TryGetValue(propName.ToUpper(), out var list))
			{
				foreach (var node in list)
					node.InnerText = datasource(Value) ?? string.Empty;
			}
		};
	}
}
