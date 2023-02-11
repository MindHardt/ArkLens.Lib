using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArkLens.Core.CharacterDraftElement;

public class CharacterDraftElementConverter<TElement> : ValueConverter<CharacterDraftElement<TElement>, string?>
	where TElement : CharacterElement, ICharacterElementEnumeration<TElement>
{
	public CharacterDraftElementConverter() 
		: base(
			v => v.Name,
			v => new() { Name = v } )
	{
	}
}
