using HomeWorkoutMAUI.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddOptions();
            builder.Services.AddAntDesign();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7057") });
            builder.Services.AddSingleton<ExerciseService>();
            builder.Services.AddApiAuthorization();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            return builder.Build();
        }
    }
}