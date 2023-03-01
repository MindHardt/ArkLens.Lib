using ArkLens.Abstractions;
using ArkLens.Models.Builders;

namespace ArkLens.Models.Snapshots;

public record CharacterSnapshot : ISnapshot<CharacterBuilder>
{
	public string? Name { get; set; }
	//public required string? Class { get; init; }
	public string? Race { get; set; }
	public string? Alignment { get; set; }
	public string? Sex { get; set; }

	public CharacterBuilder CreateBuilder()
		=> new()
		{
			Name = Name,
			Race = Race,
			Alignment = Alignment,
			Sex = Sex,
		};
}
