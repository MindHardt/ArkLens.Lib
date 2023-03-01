namespace ArkLens.Abstractions;

/// <summary>
/// Indicates that implementing type is a plain dto-like snapshot
/// and adds functionality to create a <typeparamref name="TBuilder"/>
/// with initial values.
/// </summary>
/// <typeparam name="TBuilder"></typeparam>
public interface ISnapshot<TBuilder>
{
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
