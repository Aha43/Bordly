using Bordly.Business;
using Bordly.MauiBlazor.Data;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Bordly.MauiBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddBordlyServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}