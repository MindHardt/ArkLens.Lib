using ArkLens.Core;

namespace ArkLens.Models.Races.Common;

public class Kitsune : Race, ISingleton<Kitsune>
{
	private Kitsune() : base("🦊", "Кицуне")
	{
	}

	public static Kitsune Value { get; } = new();

	public override RaceStatInfluence? StatInfluence { get; } = new(
		Dex: Stats.RaceImpact.Amplified,
		Cha: Stats.RaceImpact.Amplified,
		Str: Stats.RaceImpact.Lowered);
}
