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
	/// Represents all possible values of <typeparamref name="TSelf"/>.
	/// </summary>
	static abstract IReadOnlyList<TSelf> All { get; }
}
