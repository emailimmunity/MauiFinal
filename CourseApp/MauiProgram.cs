using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using CourseApp.Services;
using CourseApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; // Logging hinzufügen

namespace CourseApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Logging nur im Debug-Modus aktivieren
#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Dependency Injection
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<CourseRegistrationViewModel>();

            // Hinzufügen der Pages
            builder.Services.AddTransient<Views.LoginPage>();
            builder.Services.AddTransient<Views.ProfilePage>();
            builder.Services.AddTransient<Views.CourseRegistrationPage>();

            return builder.Build();
        }
    }
}