using CommunityToolkit.Maui;
using FF.ViewModels;
using FF.Views;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace FF
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit()
            .UseSkiaSharp().UseLiveCharts(); // <-- fragment, który należy dodać

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<MainViewModel>();
            return builder.Build();
        }
    }
}
