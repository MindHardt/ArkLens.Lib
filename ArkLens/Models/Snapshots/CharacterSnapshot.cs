using ArkLens.Abstractions;
using ArkLens.Models.Builders;

namespace ArkLens.Models.Snapshots;

public record CharacterSnapshot : ISnapshot<CharacterBuilder, CharacterSnapshot>
{
	public string? Name { get; set; }
	//public required string? Class { get; init; }
	public string? Race { get; set; }
	public string? Alignment { get; set; }
	public string? Sex { get; set; }

	public static CharacterSnapshot FromBuilder(CharacterBuilder builder)
		=> new()
		{
			Name = builder.Name,
			Race = builder.Race.Name,
			Alignment = builder.Alignment.Name,
			Sex = builder.Sex.Name,
		};

	public CharacterBuilder CreateBuilder()
		=> new()
		{
			Name = Name,
			Race = Race,
			Alignment = Alignment,
			Sex = Sex,
		};
}
