namespace ArkLens.Core;

public interface ICharacterElementEnumeration<TSelf> : IEnumeration<TSelf>
	where TSelf : CharacterElement, ICharacterElementEnumeration<TSelf>
{
	static TSelf? GetByName(string? name)
		=> TSelf.All
		.FirstOrDefault(e => e.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
}
