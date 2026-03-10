using to_do.View;
namespace to_do
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PopUpPage), typeof(PopUpPage));
        }
    }
}
