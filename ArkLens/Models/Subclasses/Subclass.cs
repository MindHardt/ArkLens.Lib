using ArkLens.Core;
using ArkLens.Models.Alignments;

namespace ArkLens.Models.Subclasses;

public abstract class Subclass : ArklensElement
{
	public Subclass(string emoji, string name) : base(emoji, name)
	{
	}

	/// <summary>
	/// If this <see cref="Subclass"/> restricts <see cref="Alignment"/>s
	/// for character, this property contains allowed <see cref="Alignment"/>s. Otherwise
	/// it is always <see langword="null"/>.
	/// </summary>
	public abstract IReadOnlySet<Alignment>? PossibleAlignments { get; }
}
