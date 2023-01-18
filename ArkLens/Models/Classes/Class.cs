using ArkLens.Core;

namespace ArkLens.Models.Professions;

public abstract class Class : CharacterElement, ICharacterElementEnumeration<Class>
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


}
