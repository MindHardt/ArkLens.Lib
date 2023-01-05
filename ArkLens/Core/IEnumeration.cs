namespace ArkLens.Core;

/// <summary>
/// A wrapper for enumeration classes with only pre-defined values.
/// Classes that implement <see cref="IEnumeration{TSelf}"/>
/// are expected to not have public constructors.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IEnumeration<TSelf>
	where TSelf : IEnumeration<TSelf>
{
	/// <summary>
	/// Represets all possible values of this <see cref="IEnumeration{TSelf}"/>.
	/// </summary>
	static abstract IReadOnlyList<TSelf> All { get; }
}
