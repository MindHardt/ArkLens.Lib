using ArkLens.Core;

namespace ArkLens.Models.Races.Common;

public class Elf : Race, ISingleton<Elf>
{
	private Elf() : base("🧝", "Эльф")
	{
	}

	public static Elf Value { get; } = new();

	public override RaceStatInfluence? StatInfluence { get; } = new(
		Dex: Stats.RaceImpact.Amplified,
		Int: Stats.RaceImpact.Amplified,
		Con: Stats.RaceImpact.Lowered);
}
