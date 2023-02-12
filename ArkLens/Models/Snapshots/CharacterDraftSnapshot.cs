using ArkLens.Models.Drafts;

namespace ArkLens.Models.Snapshots;

public record CharacterDraftSnapshot : ISnapshot<CharacterDraftSnapshot, CharacterDraft>
{
	public required string? Name { get; set; }
	//public required string? Class { get; init; }
	public required string? Race { get; set; }
	public required string? Alignment { get; set; }

	public CharacterDraftSnapshot FillFrom(CharacterDraft value)
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
