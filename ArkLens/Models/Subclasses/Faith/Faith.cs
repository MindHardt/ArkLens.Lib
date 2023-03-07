using ArkLens.Models.Alignments;
using System.Collections.Immutable;

namespace ArkLens.Models.Subclasses.Faith;

public abstract class Faith : Subclass
{
	protected Faith(string emoji, string name) : base(emoji, name)
	{
	}

	public abstract Alignment DeityAlignment { get; }
	public override IReadOnlySet<Alignment> AllowedAlignments => Alignment.PossibleValues
		.Where(a => a.DistanceTo(DeityAlignment) <= 1)
		.ToImmutableHashSet();


}
