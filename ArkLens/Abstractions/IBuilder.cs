namespace ArkLens.Abstractions;

/// <summary>
/// Indicates that implementing type is a builder type that
/// has freely changeable properties and can be used
/// to create <typeparamref name="TModel"/> objects.
/// </summary>
/// <typeparam name="TModel"></typeparam>
/// <typeparam name="TSelf">The implementing type.</typeparam>
public interface IBuilder<TModel, TSelf>
	where TSelf : IBuilder<TModel, TSelf>
{
	/// <summary>
	/// Creates a <typeparamref name="TSelf"/> object with data of
	/// <paramref name="model"/>.
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	public abstract static TSelf FromModel(TModel model);

	/// <summary>
	/// Creates a model from this <see cref="IBuilder{TModel}"/>.
	/// This method can throw <see cref="Exception"/>s, it is recommended to
	/// check <see cref="IsComplete()"/> before calling.
	/// </summary>
	/// <returns>A complete <typeparamref name="TModel"/> object.</returns>
	public TModel Build();

	/// <summary>
	/// Checks if all necessary fields and properties are filled
	/// and this <see cref="IBuilder{TModel}"/> is ready to be
	/// built via <see cref="Build()"/>.
	/// </summary>
	/// <returns>
	/// <see langword="true"/> if this <see cref="IBuilder{TModel}"/>
	/// can be built via <see cref="Build()"/> throwing no exceptions,
	/// otherwise <see langword="false"/>.
	/// </returns>
	public bool IsComplete();
}
