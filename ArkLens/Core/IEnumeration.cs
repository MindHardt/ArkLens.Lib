namespace ArkLens.Core;

/// <summary>
/// Exposes a static collection of pre-defined allowed values.
/// <typeparamref name="TSelf"/> should not expose any public constructors.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IEnumeration<TSelf>
	where TSelf : IEnumeration<TSelf>
{
	/// <summary>
	/// Represets all possible values of this <see cref="IEnumeration{TSelf}"/>.
	/// </summary>
	static abstract IReadOnlyList<TSelf> PossibleValues { get; }
}
