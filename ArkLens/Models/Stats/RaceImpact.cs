namespace ArkLens.Models.Stats;

/// <summary>
/// Defines how <see cref="Races.Race"/> can affect <see cref="Stat"/>s value.
/// </summary>
public enum RaceImpact : sbyte
{
	/// <summary>
	/// <see cref="Races.Race"/> has no effect on <see cref="Stat"/>
	/// </summary>
	Unaffected = 0,
	/// <summary>
	/// <see cref="Races.Race"/> lowers <see cref="Stat"/> by 2.
	/// </summary>
	Lowered = -2,
	/// <summary>
	/// <see cref="Races.Race"/> amplifies <see cref="Stat"/> by 2.
	/// </summary>
	Amplified = +2,
}
