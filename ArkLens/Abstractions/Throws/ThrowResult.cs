using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws;

public record ThrowResult
{
	/// <summary>
	/// The <see cref="Die"/> object used for throws.
	/// </summary>
	public required Die Die { get; init; }
	/// <summary>
	/// The results of dice throws.
	/// </summary>
	public required IReadOnlyList<int> Throws { get; init; }
	/// <summary>
	/// 
	/// </summary>
	public required int Modifyer { get; init; }
	/// <summary>
	/// The total sum of <see cref="Throws"/>, <see cref="Modifyer"/> and ...
	/// </summary>
	public int Sum { get; }

	// TODO: ADD BUFFS.
	public ThrowResult(Die die, int modifyer = 0, int count = 1)
	{
		Die = die;
		Throws = Die.GetResults(count).ToArray();
		Modifyer = modifyer;

		Sum = Throws.Sum() + Modifyer;
	}

	public static implicit operator int(ThrowResult result) => result.Sum;
}
