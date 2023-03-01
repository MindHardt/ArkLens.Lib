using ArkLens.Core;

namespace ArkLens.Models;

/// <summary>
/// Represents the biological sex of the character. It does not influence anything and is only
/// informative.
/// </summary>
public class Sex : ArklensElement, IArklensElementEnumeration<Sex>
{
	public Sex(string emoji, string name) : base(emoji, name)
	{
	}

	/// <summary>
	/// The biological male.
	/// </summary>
	public static Sex Male { get; } = new("♂", "Мужчина");
	/// <summary>
	/// The biological female.
	/// </summary>
	public static Sex Female { get; } = new("♀", "Женщина");

	public static IReadOnlyList<Sex> PossibleValues => new[] { Male, Female } ;
}
