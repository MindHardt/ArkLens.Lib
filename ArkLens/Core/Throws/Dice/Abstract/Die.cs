namespace ArkLens.Core.Throws.Dice.Abstract;

/// <summary>
/// A base class for all random dices.
/// </summary>
public abstract class Die
{
    /// <summary>
    /// The inclusive lowest possible value of this <see cref="Die"/>.
    /// </summary>
    public virtual int Min { get; } = 1;
    /// <summary>
    /// The inclusive highest possible value of this <see cref="Die"/>.
    /// </summary>
    public abstract int Max { get; }
    /// <summary>
    /// Throws this dice one time.
    /// </summary>
    /// <returns>
    /// <see cref="int"/> that is higher or equal to <see cref="Min"/>
    /// and lower or equal to <see cref="Max"/>.
    /// </returns>
    public abstract int GetResult();
    /// <summary>
    /// Throws this dice <paramref name="count"/> times.
    /// </summary>
    /// <param name="count"></param>
    /// <returns>
    /// A lazily-evaluated <see cref="IEnumerable{T}"/> of <see cref="int"/>,
    /// all of which are higher or equal to <see cref="Min"/>
    /// and lower or equal to <see cref="Max"/>.
    /// </returns>
    public IEnumerable<int> GetResults(int count) =>
        Enumerable.Range(0, count)
        .Select(_ => GetResult());
}
