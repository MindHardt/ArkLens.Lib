using ArkLens.Core;

namespace ArkLens.Models.Races.Common;

public class Minas : Race, ISingleton<Minas>
{
	private Minas() : base("♉", "Минас")
	{
	}

	public static Minas Static { get; } = new();

	public override RaceStatInfluence? StatInfluence { get; } = new(
		Str: Stats.RaceImpact.Amplified,
		Con: Stats.RaceImpact.Amplified,
		Int: Stats.RaceImpact.Lowered);
}
