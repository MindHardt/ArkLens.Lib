namespace ArkLens.Models.Snapshots;

/// <summary>
/// Implements logic for building plain snapshots that can work as DTOs or database Entities.
/// </summary>
/// <typeparam name="TSelf">The implementing type.</typeparam>
/// <typeparam name="TObject">The object being represented.</typeparam>
public interface ISnapshot<TSelf, TObject>
{
	/// <summary>
	/// Creates <typeparamref name="TSelf"/> object that represents <paramref name="value"/>.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public abstract static TSelf CreateFrom(TObject value);
	/// <summary>
	/// Uses this <typeparamref name="TSelf"/> to build new <typeparamref name="TObject"/>.
	/// </summary>
	/// <returns></returns>
	public TObject Build();

}
