using CommunityToolkit.Maui;
using DevExpress.Maui;
using TimeManagementAppGui.ViewModel;
using TmaLib.Services;

namespace TimeManagementAppGui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseDevExpress()
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<IAddEmployerService, AddEmployerService>();
		builder.Services.AddSingleton<SchedulerViewModel>();

        builder.Services.AddTransient<MonthView>();
        return builder.Build();
	}
}
