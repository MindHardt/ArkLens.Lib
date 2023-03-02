using ArkLens.Core;
using ArkLens.Models.Alignments;
using ArkLens.Models.Stats;

namespace ArkLens.Models.Classes;

public abstract class Class : ArklensElement, IArklensElementEnumeration<Class>
{
	protected Class(string emoji, string name) : base(emoji, name)
	{
	}

	public static IReadOnlyList<Class> All => null;

	/// <summary>
	/// The amount of Health gained per-level for this <see cref="Class"/>.
	/// </summary>
	public abstract int HpGain { get; }
	/// <summary>
	/// The amount of skill points gained per-level for this <see cref="Class"/>.
	/// </summary>
	public abstract int SkillPoints { get; }
	/// <summary>
	/// The stats priority of this <see cref="Class"/>.
	/// </summary>
	public abstract StatsPrority StatsPrority { get; }
	/// <summary>
	/// Contains <see cref="Alignment"/>s that this <see cref="Class"/> can take.
	/// </summary>
	public virtual IReadOnlySet<Alignment>? AllowedAlignments { get; } = null;
}
