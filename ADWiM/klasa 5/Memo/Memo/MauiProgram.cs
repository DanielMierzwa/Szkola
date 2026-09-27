using Microsoft.Extensions.Logging;
using Memo.ViewModels;
using Memo.Views;

namespace Memo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular");

                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<GamePage>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<GameViewModel>();

        return builder.Build();
    }
}
