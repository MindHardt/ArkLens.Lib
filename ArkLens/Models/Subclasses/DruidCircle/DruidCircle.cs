using ArkLens.Models.Alignments;

namespace ArkLens.Models.Subclasses.DruidCircle;

public abstract class DruidCircle : Subclass
{
	protected DruidCircle(string emoji, string name) : base(emoji, name)
	{
	}
	public override IReadOnlySet<Alignment>? AllowedAlignments => null;
}
