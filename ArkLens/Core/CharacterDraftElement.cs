using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ArkLens.Core;

/// <summary>
/// A helper class for character building and 
/// serialization of <see cref="ICharacterElementEnumeration{TSelf}"/> values.
/// </summary>
/// <typeparam name="TElement"></typeparam>
public class CharacterDraftElement<TElement> : INotifyPropertyChanged
    where TElement : CharacterElement, ICharacterElementEnumeration<TElement>
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
    /// The value. If set, also sets <see cref="Name"/>. This property is ignored in Json.
    /// </summary>
    [JsonIgnore]
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

    public override bool Equals(object? obj)
        => ReferenceEquals(obj, this) ||
        obj is CharacterDraftElement<TElement> other &&
        Name == other.Name &&
        Value == other.Value;

    public override int GetHashCode()
        => HashCode.Combine(Name, Value);

    public override string ToString()
        => $"{Name};{Value}";

    private void AdjustName() => _name = Value?.Name;
    private void AdjustValue() => _value = ICharacterElementEnumeration<TElement>.GetByName(Name);


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    public static implicit operator CharacterDraftElement<TElement>(string? value)
        => FromName(value);

    /// <summary>
    /// Creates a new <see cref="CharacterDraftElement{TElement}"/> with 
    /// <see cref="Name"/> set to <paramref name="name"/>.
    /// This can be replaced with an implicit cast from <see cref="string"/>.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static CharacterDraftElement<TElement> FromName(string? name)
        => new()
        {
            Name = name,
        };

}
