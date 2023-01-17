using ArkLens.Core;

namespace ArkLens.Models.Races.Common;

public class Serpent : Race, ISingleton<Serpent>
{
	private Serpent() : base("🦎", "Серпент")
	{
	}

	public static Serpent Value { get; } = new();

	public override RaceStatInfluence? StatInfluence { get; } = new(
		Con: Stats.RaceImpact.Amplified,
		Int: Stats.RaceImpact.Amplified,
		Wis: Stats.RaceImpact.Lowered);
}
