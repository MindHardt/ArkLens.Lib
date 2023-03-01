using ArkLens.Abstractions;

namespace ArkLens;

/// <summary>
/// A class with various extension methods.
/// </summary>
public static class Extensions
{
	/// <summary>
	/// A shortcut for creating models from snapshots
	/// if there is an intermediate <see cref="IBuilder{TModel}"/> class.
	/// </summary>
	/// <typeparam name="TModel"></typeparam>
	/// <param name="snapshot"></param>
	/// <returns></returns>
	public static TModel CreateModel<TModel>(this ISnapshot<IBuilder<TModel>> snapshot)
		=> snapshot.CreateBuilder().Build();
}
