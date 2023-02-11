using ArkLens.Models.Drafts;

namespace ArkLens.Models.Snapshots;

public record CharacterDraftSnapshot : ISnapshot<CharacterDraftSnapshot, CharacterDraft>
{
	public ulong? Id { get; init; }
	public required string? Name { get; init; }
	//public required string? Class { get; init; }
	public required string? Race { get; init; }
	public required string? Alignment { get; init; }

	public static CharacterDraftSnapshot CreateFrom(CharacterDraft value)
		=> new()
		{
			Name = value.Name,
			Race = value.Race.Name,
			Alignment = value.Alignment.Name,
		};

	public CharacterDraft Build()
		=> new()
		{
			Name = Name,
			Race = Race,
			Alignment = Alignment,
		};
}
