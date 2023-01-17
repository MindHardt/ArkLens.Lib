using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice;

internal class DefaultD6 : D6
{
	private readonly Random random;

	public DefaultD6(Random random)
	{
		this.random = random;
	}

	public override int GetResult() => random.Next(Min, Max + 1);
}
