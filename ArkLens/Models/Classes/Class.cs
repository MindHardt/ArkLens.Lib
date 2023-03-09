using ArkLens.Core;
using ArkLens.Extensions;
using ArkLens.Models.Alignments;
using ArkLens.Models.Stats;
using ArkLens.Models.Subclasses;

namespace ArkLens.Models.Classes;

public abstract class Class : ArklensElement, IArklensElementEnumeration<Class>
{
	protected Class(string emoji, string name) : base(emoji, name)
	{
	}

	public static IReadOnlyList<Class> All => SingletonHelper.AllSingletons
		.OfType<Class>()
		.ToList();

	/// <summary>
	/// The amount of Health gained per-level for this <see cref="Class"/>.
	/// </summary>
	public abstract int HpGain { get; }
	/// <summary>
	/// The amount of skill points gained per-level for this <see cref="Class"/>.
	/// </summary>
	public abstract int SkillPoints { get; }
	/// <summary>
	/// Contains <see cref="Stats.StatsPrority"/> object for this <see cref="Class"/>
	/// </summary>
	public abstract StatsPrority StatsPrority { get; }
	/// <summary>
	/// If this <see cref="Class"/> restricts <see cref="Alignment"/> of its owner,
	/// this property holds all possible values of <see cref="Alignment"/>.
	/// </summary>
	public virtual IReadOnlySet<Alignment>? AllowedAlignments => null;
	/// <summary>
	/// A collection of <see cref="Subclass"/> objects suitable for this <see cref="Class"/>.
	/// Contains <see langword="null"/> if this <see cref="Class"/> does not expect any
	/// <see cref="Subclass"/>es.
	/// </summary>
	public virtual IReadOnlySet<Subclass>? Subclasses => null;
	/// <summary>
	/// Returns <see langword="true"/> if this <see cref="Class"/> 
	/// requires a <see cref="Subclass"/>, otherwise <see langword="false"/>.
	/// </summary>
	public bool IsSubclassRequired => Subclasses is not null;
}
