using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice;

internal class DefaultD10 : D10
{
	private readonly Random random;

	public DefaultD10(Random random)
	{
		this.random = random;
	}

	public override int GetResult() => random.Next(Min, Max + 1);
}