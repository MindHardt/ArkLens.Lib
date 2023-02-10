using System.Xml;

namespace ArkLens.Core;

/// <summary>
/// Allows to create a dynamic svg file for <typeparamref name="T"/> type,
/// it is expected to update itself on change of <see cref="Value"/>.
/// </summary>
/// <typeparam name="T"></typeparam>
internal interface IDynamicSvg<T>
{
    /// <summary>
    /// The XML document containing SVG with all values set.
    /// </summary>
    public XmlDocument Xml { get; }
    /// <summary>
    /// The resulting svg as <see cref="string"/>. It is a shortcut for <see cref="Xml"/>.OuterXml.
    /// </summary>
    public string Result => Xml.OuterXml;
    /// <summary>
    /// The <typeparamref name="T"/> being represented.
    /// </summary>
    public T Value { get; }
}
