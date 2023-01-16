using TimeManagementAppGui.View;

namespace TimeManagementAppGui;

public partial class App : Application
{
	public App()
	{
		InitializeRouting();

        InitializeComponent();

		MainPage = new AppShell();
	}

	private static void InitializeRouting()
	{
        Routing.RegisterRoute("AddEntry", typeof(AddTimeEntry));
		Routing.RegisterRoute("Appointments", typeof(AppointmentsPage));
		Routing.RegisterRoute("//Main/Calendar", typeof(MonthView));
    }
}
