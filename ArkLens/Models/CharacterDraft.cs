using ArkLens.Core;
using ArkLens.Models.Races;
using ArkLens.Models.Stats;

namespace ArkLens.Models;

public class CharacterDraft
{
	public string? Name { get; set; }

	public StatSet Stats { get; init; } = new();

	public CharacterDraftElement<Race> Race { get; } = new();
}
