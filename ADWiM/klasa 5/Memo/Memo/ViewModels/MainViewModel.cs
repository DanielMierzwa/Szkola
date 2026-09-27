using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memo.Models;

namespace Memo.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private DifficultyLevel? level;

    public string EasyText => "Łatwy\n4 pary";

    public string MediumText => "Średni\n6 par";

    public string HardText => "Trudny\n8 par";

    [RelayCommand]
    private async Task StartGameAsync(DifficultyLevel level)
    {
        Level = level;

        await Shell.Current.GoToAsync(
            "GamePage",
            new Dictionary<string, object>
            {
                ["Difficulty"] = level
            });
    }
}
