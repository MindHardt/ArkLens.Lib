using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice.Default;

internal class DefaultDie : Die
{
	private readonly Random random;
	public override int Max { get; }

	public override int GetResult() => random.Next(Min, Max + 1);

	public DefaultDie(Random random, int max)
	{
		this.random = random;
		Max = max;
	}
}
