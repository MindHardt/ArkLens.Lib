namespace ArkLens.Core;

/// <summary>
/// Exposes a singleton static value for one-value classes.
/// <typeparamref name="TSelf"/> should not expose any public constructors.
/// </summary>
public interface ISingleton<TSelf>
	where TSelf : ISingleton<TSelf>
{
	/// <summary>
	/// The static value of <typeparamref name="TSelf"/>.
	/// </summary>
	public static abstract TSelf Static { get; }
}
