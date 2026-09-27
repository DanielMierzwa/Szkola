using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Memo.Models;

public partial class Card : ObservableObject
{
    private readonly Func<Card, Task> _selectAction;

    public int PairId { get; }

    public string ImageName { get; }

    public string ImageSource =>
        IsSelected || IsMatched
            ? ImageName
            : "card_back.png";

    public Color BackgroundColor =>
        IsMatched
            ? Color.FromArgb("#DCFCE7")
            : IsSelected
                ? Color.FromArgb("#DBEAFE")
                : Colors.White;

    public bool CanSelect =>
        !IsSelected && !IsMatched;

    [ObservableProperty]
    private bool isSelected;

    [ObservableProperty]
    private bool isMatched;

    public Card(
        int pairId,
        string imageName,
        Func<Card, Task> selectAction)
    {
        PairId = pairId;
        ImageName = imageName;
        _selectAction = selectAction;
    }

    partial void OnIsSelectedChanged(bool value)
    {
        OnPropertyChanged(nameof(ImageSource));
        OnPropertyChanged(nameof(BackgroundColor));
        OnPropertyChanged(nameof(CanSelect));

        SelectCommand.NotifyCanExecuteChanged();
    }

    partial void OnIsMatchedChanged(bool value)
    {
        OnPropertyChanged(nameof(ImageSource));
        OnPropertyChanged(nameof(BackgroundColor));
        OnPropertyChanged(nameof(CanSelect));

        SelectCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(
        CanExecute = nameof(CanBeSelected),
        AllowConcurrentExecutions = true)]
    private async Task SelectAsync()
    {
        if (!CanBeSelected())
            return;

        IsSelected = true;

        await _selectAction(this);
    }

    private bool CanBeSelected()
    {
        return CanSelect;
    }
}
