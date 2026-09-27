using Memo.Views;

namespace Memo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            "GamePage",
            typeof(GamePage));
    }
}
