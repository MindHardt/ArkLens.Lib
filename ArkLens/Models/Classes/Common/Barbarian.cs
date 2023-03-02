using ArkLens.Core;
using ArkLens.Models.Alignments;
using ArkLens.Models.Stats;
using System.Collections.Immutable;

namespace ArkLens.Models.Classes.Common;

public class Barbarian : Class, ISingleton<Barbarian>
{
    private Barbarian()
        : base("😡", "Варвар")
    {
    }

    public static Barbarian Static { get; } = new();

    public override int HpGain => 12;

    public override int SkillPoints => 3;

    public override StatsPrority StatsPrority { get; }

	public override IReadOnlySet<Alignment>? AllowedAlignments 
        => Alignment.All.Where(a => a.Horizontal != HorizontalAlignment.Lawful).ToImmutableHashSet();
}
