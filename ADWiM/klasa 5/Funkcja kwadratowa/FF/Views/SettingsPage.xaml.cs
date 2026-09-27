using FF.ViewModels;

namespace FF.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(MainViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}