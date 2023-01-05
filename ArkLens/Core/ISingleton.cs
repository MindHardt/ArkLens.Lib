namespace ArkLens.Core;

/// <summary>
/// Exposes a singleton static value for one-value classes.
/// <typeparamref name="TSelf"/> should not expose any public constructors.
/// </summary>
public interface ISingleton<TSelf>
	where TSelf : ISingleton<TSelf>
{
	/// <summary>
	/// The only possible value of <typeparamref name="TSelf"/>.
	/// </summary>
	static abstract TSelf Value { get; }
}
