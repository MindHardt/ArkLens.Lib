using ArkLens.Models.Alignments;

namespace ArkLens.Models.Subclasses.WizardSchool;

public abstract class WizardSchool : Subclass
{
    protected WizardSchool(string emoji, string name) : base(emoji, name)
    {
    }
	public override IReadOnlySet<Alignment>? AllowedAlignments => null;
}
