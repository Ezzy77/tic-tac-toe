using Microsoft.Extensions.Logging;
using tic_tac_toe.Services;
using tic_tac_toe.Views;

namespace tic_tac_toe;

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
		

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<AuthService>();
		builder.Services.AddTransient<LoadingPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<RegisterPage>();
		
		return builder.Build();
	}
}

