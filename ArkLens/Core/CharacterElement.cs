namespace ArkLens.Core;

/// <summary>
/// A base class for Arklens character elements with name and emoji parts.
/// <see cref="CharacterElement"/>s are compared based on their <see cref="Emoji"/>
/// and <see cref="Name"/> properties.
/// </summary>
public abstract class CharacterElement : IEquatable<CharacterElement>
{
	/// <summary>
	/// The text emoji of this <see cref="CharacterElement"/>.
	/// This is expected to be Unicode emoji and not guaranteed to be unique.
	/// </summary>
	public string Emoji { get; }
	/// <summary>
	/// The text name of this <see cref="CharacterElement"/>.
	/// This is expected to be unique across 
	/// different <see cref="CharacterElement"/> objects.
	/// </summary>
	public string Name { get; }

	public CharacterElement(string emoji, string name)
	{
		Emoji = emoji;
		Name = name;
	}

	public override bool Equals(object? obj)
		=> ReferenceEquals(this, obj) ||
		obj is CharacterElement other &&
		other.Emoji == Emoji &&
		other.Name == Name;

	public override int GetHashCode()
		=> HashCode.Combine(Emoji, Name);

	/// <summary>
	/// Returns a <see cref="string"/> that represents the current
	/// <see cref="CharacterElement"/>, containing both 
	/// <see cref="Emoji"/> and <see cref="Name"/>.
	/// </summary>
	/// <returns></returns>
	public override string ToString()
		=> $"{Emoji} {Name}";

	/// <summary>
	/// Indicates whether this <see cref="CharacterElement"/> is equal to
	/// <paramref name="other"/>.
	/// </summary>
	/// <param name="other"></param>
	/// <returns>
	/// <see langword="true"/> if current <see cref="CharacterElement"/> is
	/// equal to <paramref name="other"/>; otherwise <see langword="false"/>.
	/// </returns>
	public bool Equals(CharacterElement? other)
		=> Equals(this, other);

	public static bool operator ==(CharacterElement? left, CharacterElement? right)
		=> Equals(left, right);

	public static bool operator !=(CharacterElement? left, CharacterElement? right)
		=> !Equals(left, right);
}
