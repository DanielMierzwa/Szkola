using FF.ViewModels;
using FF.Views;

namespace FF
{
    public partial class MainPage : ContentPage
    {
        private bool _isClosingApp;
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            // Tworzenie okna z ustawieniami
            var settingsWindow = new Window(new SettingsPage(vm)) // <-- SettingsPage to po prostu samodzielna strona XAML
            {
                Title = "Settings",
                Width = 400,
                Height = 550
            };
            Application.Current.OpenWindow(settingsWindow);
            this.Loaded += (_, _) =>
            {
                this.Window.Destroying += (_, _) => Application.Current.Quit();
                settingsWindow.Destroying += (_, _) => Application.Current.Quit();
            };
        }
    }

        


    
}
