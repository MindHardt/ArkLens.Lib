using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice;

internal class DefaultD3 : D3
{
	private readonly Random random;

	public DefaultD3(Random random)
	{
		this.random = random;
	}

	public override int GetResult() => random.Next(Min, Max + 1);
}
