using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class ResultsPage : ContentPage
{
	public ResultsPage(ResultsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ResultsViewModel)?.OnAppearing();
    }

}