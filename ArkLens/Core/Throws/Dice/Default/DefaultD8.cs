using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice;

internal class DefaultD8 : D8
{
	private readonly Random random;

	public DefaultD8(Random random)
	{
		this.random = random;
	}

	public override int GetResult() => random.Next(Min, Max + 1);
}