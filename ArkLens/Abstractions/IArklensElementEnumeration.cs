namespace ArkLens.Core;

/// <summary>
/// Specifies additional functionality for <see cref="IEnumeration{TSelf}"/>
/// applied to <see cref="ArklensElement"/>. Allows searching for value by
/// <see cref="ArklensElement.Name"/>
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IArklensElementEnumeration<TSelf> : IEnumeration<TSelf>
	where TSelf : ArklensElement, IArklensElementEnumeration<TSelf>
{
	/// <summary>
	/// Gets <typeparamref name="TSelf"/> with <see cref="ArklensElement.Name"/>
	/// equal to <paramref name="name"/> or <see langword="null"/> if none is found.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="comparison">
	/// <see cref="StringComparison"/> used to check if <paramref name="name"/> is
	/// equal to <see cref="ArklensElement.Name"/>.
	/// </param>
	/// <returns></returns>
	static TSelf? GetByName(string? name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
		=> TSelf.All
		.FirstOrDefault(e => e.Name.Equals(name, comparison));
}
