using ArkLens.Core;

namespace ArkLens.Models.Races.Common;

public class Human : Race, ISingleton<Human>
{
	private Human() : base("🧑", "Человек")
	{
	}

	public static Human Static { get; } = new();

	public override RaceStatInfluence? StatInfluence => null;
}
