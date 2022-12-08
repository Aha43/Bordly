using Bordly.Business;
using Bordly.MauiBlazor.Data;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
//using static MudBlazor.CategoryTypes;

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

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
#if DEBUG
                //MessageBox.Show(text: error.ExceptionObject.ToString(), caption: "Error");
                var err = error.ExceptionObject.ToString();
#else
    MessageBox.Show(text: "An error has occurred.", caption: "Error");
#endif

                // Log the error information (error.ExceptionObject)
            };

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}