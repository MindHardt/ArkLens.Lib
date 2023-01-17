using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice;

internal class DefaultD20 : D20
{
	private readonly Random random;

	public DefaultD20(Random random)
	{
		this.random = random;
	}

	public override int GetResult() => random.Next(Min, Max + 1);
}
