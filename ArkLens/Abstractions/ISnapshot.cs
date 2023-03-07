namespace ArkLens.Abstractions;

/// <summary>
/// Indicates that implementing type is a plain dto-like snapshot
/// and adds functionality to create a <typeparamref name="TBuilder"/>
/// with initial values.
/// </summary>
/// <typeparam name="TBuilder"></typeparam>
/// <typeparam name="TSelf">The implementing type.</typeparam>
public interface ISnapshot<TBuilder, TSelf>
	where TSelf : ISnapshot<TBuilder, TSelf>
{
	/// <summary>
	/// Creates a <typeparamref name="TSelf"/> with the data
	/// of <paramref name="builder"/>.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static abstract TSelf FromBuilder(TBuilder builder);
	/// <summary>
	/// Generates a <typeparamref name="TBuilder"/> from this
	/// <see cref="ISnapshot{TBuilder}"/>s data.
	/// </summary>
	/// <returns>
	/// A <typeparamref name="TBuilder"/> with data of this
	/// <see cref="ISnapshot{TBuilder}"/>.
	/// </returns>
	public TBuilder CreateBuilder();

}
