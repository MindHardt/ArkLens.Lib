using ArkLens.Models.Drafts;

namespace ArkLens.Models.Snapshots;

public record CharacterSnapshot : ISnapshot<CharacterSnapshot, CharacterDraft>
{
	public string? Name { get; set; }
	//public required string? Class { get; init; }
	public string? Race { get; set; }
	public string? Alignment { get; set; }

	public CharacterSnapshot FillFrom(CharacterDraft value)
	{
		Name = value.Name;
		Race = value.Race.Name;
		Alignment = value.Alignment.Name;
		return this;
	}

	public CharacterDraft Build()
		=> new()
		{
			Name = Name,
			Race = Race,
			Alignment = Alignment,
		};
}
