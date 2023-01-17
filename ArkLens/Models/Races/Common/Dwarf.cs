using ArkLens.Core;

namespace ArkLens.Models.Races.Common;

public class Dwarf : Race, ISingleton<Dwarf>
{
	private Dwarf() : base("🧔", "Дварф")
	{
	}

	public static Dwarf Value { get; } = new();

	public override RaceStatInfluence? StatInfluence { get; } = new(
		Con: Stats.RaceImpact.Amplified,
		Wis: Stats.RaceImpact.Amplified,
		Cha: Stats.RaceImpact.Lowered);
}
