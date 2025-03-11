using AppOracleMaui.MVVM.Model;
using AppOracleMaui.Repository;
using Microsoft.Extensions.Logging;
using ModelOracleDemo;
using Syncfusion.Maui.Core.Hosting;

namespace AppOracleMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Roboto-Black.ttf", "Strong");
                    fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");
                
                });
            builder.Services.AddSingleton<IBaseRepository<Transaction>, ApiBaseRepository<Transaction>>();
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
