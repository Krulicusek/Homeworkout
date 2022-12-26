using SharedUILibrary.Interfaces;
using SharedUILibrary.Services;

namespace HomeWorkoutMAUI
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
#if DEBUG 
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddAntDesign();

            /// when connecting from other machine than localhost u have to swap out "localhost" for an IPv4 adress
                         builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7057") });
            ///         builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.0.120:3000") });  <- to działa z iisproxy oraz proxy na emulatorze 
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.0.120:3000") });            
            builder.Services.AddSingleton<ExerciseService>();
            builder.Services.AddSingleton<HomeworkSequenceService>();
            builder.Services.AddSingleton <PatientService>();
            builder.Services.AddSingleton<IAppService, AppService>();
            builder.Services.AddSingleton<ICrudExerciseService, CrudExerciseService>();
            return builder.Build();
        }
    }
}