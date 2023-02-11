using ArkLens.Core.CharacterDraftElement;
using ArkLens.Models.Alignments;

namespace ArkLens.Models.Drafts;

public class MonsterDraft
{
    /// <summary>
    /// The name of this <see cref="MonsterDraft"/>
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The <see cref="Alignments.Alignment"/> of this <see cref="MonsterDraft"/>
    /// </summary>
    public CharacterDraftElement<Alignment> Alignment { get; } = new();

    public int Hp { get; set; } = 10;
    public string? HealthDice { get; set; }

    public int Str { get; set; } = 0;
    public int Dex { get; set; } = 0;
    public int Con { get; set; } = 0;
    public int Int { get; set; } = 0;
    public int Wis { get; set; } = 0;
    public int Cha { get; set; } = 0;

    public int Fort { get; set; } = 0;
    public int Reac { get; set; } = 0;
    public int Will { get; set; } = 0;
    public int Conc { get; set; } = 0;
    public int Perc { get; set; } = 0;

    public int Base { get; set; } = 16;
    public int Touc { get; set; } = 16;
    public int Unaw { get; set; } = 16;

    public string? Lore { get; set; }
    public string? Attacks { get; set; }
    public string? Additions { get; set; }
    public string? AvatarBase64 { get; set; }
}
