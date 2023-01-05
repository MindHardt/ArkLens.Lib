using ArkLens.Core;

namespace ArkLens.Models.Stats;

/// <summary>
/// A base class for all stats
/// </summary>
public abstract class Stat : CharacterElement
{
	#region Raw
	/// <summary>
	/// The raw value unaffected by buffs or race.
	/// </summary>
	public int RawValue { get; set; }
	/// <summary>
	/// The modifyer of <see cref="RawValue"/>.
	/// </summary>
	public int RawModifyer => ModOf(RawValue);
	#endregion


	#region Display
	/// <summary>
	/// The constant display value including <see cref="RaceImpact"/>.
	/// </summary>
	public int DisplayValue => RawValue + (sbyte)RaceImpact;
	/// <summary>
	/// The modifyer of <see cref="DisplayValue"/>.
	/// </summary>
	public int DisplayModifyer => ModOf(DisplayValue);
	#endregion


	/// <summary>
	/// The modifyer of <see cref="Value"/>. This is used for most all calculations.
	/// </summary>
	public int Modifyer => DisplayModifyer;


	/// <summary>
	/// Current <see cref="Stats.RaceImpact"/> of this <see cref="Stat"/>.
	/// </summary>
	public RaceImpact RaceImpact { get; set; }


	/// <summary>
	/// Gets modifyer of <see cref="Stat"/>s value.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	protected static int ModOf(int value) => value / 2 - 5;
	protected Stat(string emoji, string name) : base(emoji, name)
	{
	}
}
