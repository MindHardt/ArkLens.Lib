using ArkLens.Models.Races;
using ArkLens.Models.Stats.Primary;
using System.Collections;

namespace ArkLens.Models.Stats;

/// <summary>
/// Represents a collection of all six primary <see cref="Stat"/>s.
/// </summary>
public class StatSet : IEnumerable<Stat>
{
	private RaceStatInfluence _raceStatInfluence;
	private readonly IReadOnlyList<Stat> _allStats;

	public Strength Str { get; init; } = new();
	public Dexterity Dex { get; init; } = new();
	public Constitution Con { get; init; } = new();
	public Intelligence Int { get; init; } = new();
	public Wisdom Wis { get; init; } = new();
	public Charisma Cha { get; init; } = new();

	public StatSet()
	{
		_allStats = new Stat[] { Str, Dex, Con, Int, Wis, Cha };
	}

	/// <summary>
	/// Current <see cref="RaceStatInfluence"/> of this <see cref="StatSet"/>.
	/// When set it automatically adjusts all <see cref="Stat.RaceImpact"/>'s.
	/// </summary>
	public RaceStatInfluence RaceStatInfluence
	{
		get => _raceStatInfluence;
		set
		{
			Str.RaceImpact = value.Str;
			Dex.RaceImpact = value.Dex;
			Con.RaceImpact = value.Con;
			Int.RaceImpact = value.Int;
			Wis.RaceImpact = value.Wis;
			Cha.RaceImpact = value.Cha;
			_raceStatInfluence = value;
		}
	}

	public IEnumerator<Stat> GetEnumerator()
		=> _allStats.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
