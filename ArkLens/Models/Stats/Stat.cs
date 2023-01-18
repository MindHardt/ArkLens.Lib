using ArkLens.Core;
using System.Text.Json.Serialization;

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
	/// The modifier of <see cref="RawValue"/>.
	/// </summary>
	public int RawModifyer => ModOf(RawValue);
	#endregion


	#region Display
	/// <summary>
	/// The constant display value including <see cref="RaceImpact"/>.
	/// </summary>
	public int DisplayValue => RawValue + (sbyte)RaceImpact;
	/// <summary>
	/// The modifier of <see cref="DisplayValue"/>.
	/// </summary>
	public int DisplayModifyer => ModOf(DisplayValue);
	#endregion


	/// <summary>
	/// The modifier of <see cref="Value"/>. This is used for most all calculations.
	/// </summary>
	public int Modifyer => DisplayModifyer;

	/// <summary>
	/// Current <see cref="Stats.RaceImpact"/> of this <see cref="Stat"/>.
	/// This property is ignored in json because it is duplicated in several places.
	/// </summary>
	[JsonIgnore]
	public RaceImpact RaceImpact { get; set; } = RaceImpact.Unaffected;


	/// <summary>
	/// Gets modifier of <see cref="Stat"/>s value.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	protected static int ModOf(int value) => value / 2 - 5;
	protected Stat(string emoji, string name) : base(emoji, name)
	{
		RawValue = 10;
	}
}
