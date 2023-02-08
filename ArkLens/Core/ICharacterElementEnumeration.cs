namespace ArkLens.Core;

/// <summary>
/// Specifies additional functionality for <see cref="IEnumeration{TSelf}"/>
/// applied to <see cref="CharacterElement"/>.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface ICharacterElementEnumeration<TSelf> : IEnumeration<TSelf>
	where TSelf : CharacterElement, ICharacterElementEnumeration<TSelf>
{
	/// <summary>
	/// Gets <typeparamref name="TSelf"/> with <see cref="CharacterElement.Name"/>
	/// equal to <paramref name="name"/> or <see langword="null"/> if none is found.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="comparison">
	/// <see cref="StringComparison"/> used to check if <paramref name="name"/> is
	/// equal to <see cref="CharacterElement.Name"/>.
	/// </param>
	/// <returns></returns>
	static TSelf? GetByName(string? name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
		=> TSelf.PossibleValues
		.FirstOrDefault(e => e.Name.Equals(name, comparison));


}
