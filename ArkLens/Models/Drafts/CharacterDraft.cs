using ArkLens.Core;
using ArkLens.Models.Alignments;
using ArkLens.Models.Races;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ArkLens.Models.Drafts;

public class CharacterDraft : INotifyPropertyChanged
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

    public CharacterDraftElement<Alignment> Alignment { get; init; } = new();

    public CharacterDraftElement<Race> Race { get; init; } = new();

    public CharacterDraftElement<Sex> Sex { get; init; } = new();

    //public StatSet Stats { get; init; } = new();


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    public CharacterDraft()
    {
        Alignment.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Alignment));
        Race.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Race));
        Sex.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Sex));
    }


}
