using Microsoft.Extensions.Logging;
using peselCoder.ViewModels;
using CommunityToolkit.Maui;

namespace peselCoder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<DecoderViewModel>();
            builder.Services.AddTransient<EncoderViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<EncoderPage>();
            return builder.Build();
        }
    }
}
