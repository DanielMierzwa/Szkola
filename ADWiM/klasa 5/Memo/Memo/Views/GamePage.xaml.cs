using Memo.Models;
using Memo.ViewModels;

namespace Memo.Views;

public partial class GamePage : ContentPage, IQueryAttributable
{
    private readonly GameViewModel _viewModel;

    public GamePage(GameViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("Difficulty", out var value) &&
            value is DifficultyLevel difficulty)
        {
            _viewModel.InitializeGame(difficulty);
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _viewModel.Dispose();
    }
}
