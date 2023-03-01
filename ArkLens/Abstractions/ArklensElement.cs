namespace ArkLens.Core;

/// <summary>
/// A base class for Arklens character elements with name and emoji parts.
/// <see cref="ArklensElement"/>s are compared based on their <see cref="Emoji"/>
/// and <see cref="Name"/> properties.
/// </summary>
public abstract class ArklensElement : IEquatable<ArklensElement>
{
	/// <summary>
	/// The text emoji of this <see cref="ArklensElement"/>.
	/// This is expected to be Unicode emoji and not guaranteed to be unique.
	/// </summary>
	public string Emoji { get; }
	/// <summary>
	/// The text name of this <see cref="ArklensElement"/>.
	/// This is expected to be unique across 
	/// different <see cref="ArklensElement"/> objects.
	/// </summary>
	public string Name { get; }

	public ArklensElement(string emoji, string name)
	{
		Emoji = emoji;
		Name = name;
	}

	public override bool Equals(object? obj)
		=> ReferenceEquals(this, obj) ||
		obj is ArklensElement other &&
		other.Emoji == Emoji &&
		other.Name == Name;

	public override int GetHashCode()
		=> HashCode.Combine(Emoji, Name);

	/// <summary>
	/// Returns a <see cref="string"/> that represents the current
	/// <see cref="ArklensElement"/>, containing both 
	/// <see cref="Emoji"/> and <see cref="Name"/>.
	/// </summary>
	/// <returns></returns>
	public override string ToString()
		=> $"{Emoji} {Name}";

	/// <summary>
	/// Indicates whether this <see cref="ArklensElement"/> is equal to
	/// <paramref name="other"/>.
	/// </summary>
	/// <param name="other"></param>
	/// <returns>
	/// <see langword="true"/> if current <see cref="ArklensElement"/> is
	/// equal to <paramref name="other"/>; otherwise <see langword="false"/>.
	/// </returns>
	public bool Equals(ArklensElement? other)
		=> Equals(this, other);

	public static bool operator ==(ArklensElement? left, ArklensElement? right)
		=> Equals(left, right);

	public static bool operator !=(ArklensElement? left, ArklensElement? right)
		=> !Equals(left, right);
}
