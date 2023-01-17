using ArkLens.Core.Throws.Dice.Abstract;

namespace ArkLens.Core.Throws.Dice.Default;

internal class DefaultDiceSet : DiceSet
{
	private readonly Random random;
	private readonly D2 d2;
	private readonly D3 d3;
	private readonly D4 d4;
	private readonly D6 d6;
	private readonly D8 d8;
	private readonly D10 d10;
	private readonly D12 d12;
	private readonly D20 d20;
	private readonly D100 d100;

	public override D2 D2 => d2;
	public override D3 D3 => d3;
	public override D4 D4 => d4;
	public override D6 D6 => d6;
	public override D8 D8 => d8;
	public override D10 D10 => d10;
	public override D12 D12 => d12;
	public override D20 D20 => d20;
	public override D100 D100 => d100;

	public override Die CreateCustomDie(int max)
		=> new DefaultDie(random, max);

	/// <summary>
	/// Creates a <see cref="DiceSet"/> of <see cref="Random"/>-based
	/// default dice.
	/// </summary>
	/// <param name="randomOverride">
	/// A random instance used in dice.
	/// if none is specified then <see cref="Random.Shared"/> is used.
	/// </param>
	public DefaultDiceSet(Random? randomOverride = null)
	{
		random = randomOverride ?? Random.Shared;
		d2 = new DefaultD2(random);
		d3 = new DefaultD3(random);
		d4 = new DefaultD4(random);
		d6 = new DefaultD6(random);
		d8 = new DefaultD8(random);
		d10 = new DefaultD10(random);
		d12 = new DefaultD12(random);
		d20 = new DefaultD20(random);
		d100 = new DefaultD100(random);
	}
}
