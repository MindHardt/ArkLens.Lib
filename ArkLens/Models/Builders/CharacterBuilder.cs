using ArkLens.Abstractions;
using ArkLens.Models.Alignments;
using ArkLens.Models.Races;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ArkLens.Models.Builders;

public class CharacterBuilder : INotifyPropertyChanged, IBuilder<Character>
{
	private string? name;

	public string? Name
	{
		get => name;
		set
		{
			name = value;
			OnPropertyChanged();
		}
	}

	public ArklensBuilderElement<Alignment> Alignment { get; init; } = new();

	public ArklensBuilderElement<Race> Race { get; init; } = new();

	public ArklensBuilderElement<Sex> Sex { get; init; } = new();

	//public StatSet Stats { get; init; } = new();


	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	public Character Build()
		=> new()
		{
			Name = Name ?? throw new ArgumentNullException(nameof(Name)),
			Alignment = Alignment.Value ?? throw new ArgumentNullException(nameof(Alignment)),
			Race = Race.Value ?? throw new ArgumentNullException(nameof(Alignment)),
			Sex = Sex.Value ?? throw new ArgumentNullException(nameof(Sex)),
		};

	public bool IsComplete()
		=> Name is not null &&
		Alignment.HasValue() &&
		Race.HasValue() &&
		Sex.HasValue();

	public CharacterBuilder()
	{
		Alignment.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Alignment));
		Race.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Race));
		Sex.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Sex));
	}


}
