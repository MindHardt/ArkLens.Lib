namespace ArkLens.Core.Throws.Dice.Abstract;

/// <summary>
/// A base class for all DnD dice sets.
/// </summary>
public abstract class DiceSet
{
    public abstract D2 D2 { get; }
    public abstract D3 D3 { get; }
    public abstract D4 D4 { get; }
    public abstract D6 D6 { get; }
    public abstract D8 D8 { get; }
    public abstract D10 D10 { get; }
    public abstract D12 D12 { get; }
    public abstract D20 D20 { get; }
    public abstract D100 D100 { get; }
    /// <summary>
    /// Creates a custom die.
    /// </summary>
    /// <param name="max"><see cref="Die.Max"/> value for created die.</param>
    /// <returns></returns>
    public abstract Die CreateCustomDie(int max);
}
