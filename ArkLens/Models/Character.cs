using ArkLens.Models.Alignments;
using ArkLens.Models.Races;

namespace ArkLens.Models;

public class Character
{
	public required string Name { get; init; }
	public required Alignment Alignment { get; init; }
	public required Race Race { get; init; }
	public required Sex Sex { get; init; }
}
