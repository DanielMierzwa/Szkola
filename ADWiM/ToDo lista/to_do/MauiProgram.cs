using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using to_do.View;
using to_do.ViewModel;

namespace to_do
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<PopUpViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<PopUpPage>();

            return builder.Build();
        }
    }
}
