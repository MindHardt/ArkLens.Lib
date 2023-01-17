using ArkLens.Models.Stats;

namespace ArkLens.Models.Races;

/// <summary>
/// Contains information about how <see cref="Race"/> affects <see cref="StatSet"/>.
/// </summary>
/// <param name="Str">Strength</param>
/// <param name="Dex">Dexterity</param>
/// <param name="Con">Constitution</param>
/// <param name="Int">Intelligence</param>
/// <param name="Wis">Wisdom</param>
/// <param name="Cha">Charisma</param>
public readonly record struct RaceStatInfluence(
	RaceImpact Str = RaceImpact.Unaffected,
	RaceImpact Dex = RaceImpact.Unaffected,
	RaceImpact Con = RaceImpact.Unaffected,
	RaceImpact Int = RaceImpact.Unaffected,
	RaceImpact Wis = RaceImpact.Unaffected,
	RaceImpact Cha = RaceImpact.Unaffected);
