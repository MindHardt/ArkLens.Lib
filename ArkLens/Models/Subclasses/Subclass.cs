using ArkLens.Core;
using ArkLens.Models.Alignments;

namespace ArkLens.Models.Subclasses;

public abstract class Subclass : ArklensElement
{
	protected Subclass(string emoji, string name) : base(emoji, name)
	{
	}
	/// <summary>
	/// Contains all <see cref="Alignment"/>s that this <see cref="Subclass"/> allows 
	/// to take. It does not include parent <see cref="Classes.Class"/>'s restrictions
	/// and can only restrict it further.
	/// (for instance, druids are restricted by class, not by subclass).
	/// </summary>
	public abstract IReadOnlySet<Alignment>? AllowedAlignments { get; }
}
