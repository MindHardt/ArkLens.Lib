using ArkLens.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ArkLens.Abstractions;

/// <summary>
/// A helper class for building and serialization
/// of <see cref="IArklensElementEnumeration{TSelf}"/> values.
/// </summary>
/// <typeparam name="TElement"></typeparam>
public class ArklensBuilderElement<TElement> : INotifyPropertyChanged
    where TElement : ArklensElement, IArklensElementEnumeration<TElement>
{
    private string? _name;
    private TElement? _value;

    /// <summary>
    /// The string name of this value. If set, also sets <see cref="Value"/>.
    /// </summary>
    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            AdjustValue();
            OnPropertyChanged();
        }
    }
    /// <summary>
    /// The value. If set, also sets <see cref="Name"/>.
    /// </summary>
    public TElement? Value
    {
        get => _value;
        set
        {
            _value = value;
            AdjustName();
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Checks if this <see cref="ArklensBuilderElement{TElement}"/>
    /// has value set.
    /// </summary>
    /// <returns></returns>
    public bool HasValue() => Value is not null;

    public override bool Equals(object? obj)
        => ReferenceEquals(obj, this) ||
        obj is ArklensBuilderElement<TElement> other &&
        Name == other.Name &&
        Value == other.Value;

    public override int GetHashCode()
        => HashCode.Combine(Name, Value);

    public override string ToString()
        => $"{Name};{Value}";

    private void AdjustName() => _name = Value?.Name;
    private void AdjustValue() => _value = IArklensElementEnumeration<TElement>.GetByName(Name);


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    public static implicit operator ArklensBuilderElement<TElement>(string? name)
        => FromName(name);
	public static implicit operator ArklensBuilderElement<TElement>(TElement? value)
		=> FromValue(value);

	/// <summary>
	/// Creates a new <see cref="ArklensBuilderElement{TElement}"/> with 
	/// <see cref="Name"/> set to <paramref name="name"/>.
	/// This can be replaced with an implicit cast from <see cref="string"/>.
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public static ArklensBuilderElement<TElement> FromName(string? name)
        => new() { Name = name };

	/// <summary>
	/// Creates a new <see cref="ArklensBuilderElement{TElement}"/> with 
	/// <see cref="Value"/> set to <paramref name="value"/>.
	/// This can be replaced with an implicit cast from <typeparamref name="TElement"/>.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static ArklensBuilderElement<TElement> FromValue(TElement? value)
		=> new() { Value = value };
}
