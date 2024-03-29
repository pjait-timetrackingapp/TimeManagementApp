using CommunityToolkit.Maui;
using DevExpress.Maui;
using TimeManagementAppGui.View;
using TimeManagementAppGui.ViewModel;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Persistance;
using TmaLib.Repository;
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

        builder.Services.AddDbContext<TaskContext>();

        builder.Services.AddSingleton<IAddEmployerService, AddEmployerService>();
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<IEmployerRepository, EmployerRepository>();
        builder.Services.AddSingleton<ITimeEntryRepository, TimeEntryRepository>();
        builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();

        builder.Services.AddSingleton<SchedulerViewModel>();
        builder.Services.AddSingleton<SchedulerDataViewModel>();
        builder.Services.AddSingleton<AddTimeEntryViewModel>();
        builder.Services.AddSingleton<AddEmployerViewModel>();
        builder.Services.AddSingleton<EmployersViewModel>();
        builder.Services.AddSingleton<AddProjectViewModel>();

        builder.Services.AddTransient<ProjectTimeEntries>();
        builder.Services.AddTransient<MonthView>();
        builder.Services.AddTransient<AppointmentsPage>();
        builder.Services.AddTransient<AddTimeEntry>();
        builder.Services.AddTransient<Employers>();
        builder.Services.AddTransient<AddEmployerView>();
        builder.Services.AddTransient<AddProject>();
        builder.Services.AddTransient<Projects>();

        return builder.Build();
    }
}
