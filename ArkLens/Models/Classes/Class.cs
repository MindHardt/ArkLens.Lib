using ArkLens.Core;
using ArkLens.Models.Subclasses;

namespace ArkLens.Models.Classes;

public abstract class Class : ArklensElement, IArklensElementEnumeration<Class>
{
	protected Class(string emoji, string name) : base(emoji, name)
	{
	}

	public static IReadOnlyList<Class> PossibleValues => null;

	/// <summary>
	/// The amount of Health gained per-level for this <see cref="Class"/>.
	/// </summary>
	public abstract int HpGain { get; }
	/// <summary>
	/// The amount of skill points gained per-level for this <see cref="Class"/>.
	/// </summary>
	public abstract int SkillPoints { get; }
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
