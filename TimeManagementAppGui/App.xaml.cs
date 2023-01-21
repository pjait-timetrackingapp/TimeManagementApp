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
		Routing.RegisterRoute("AddEmployer", typeof(AddEmployerView));
		Routing.RegisterRoute("AddProject", typeof(AddProject));
		Routing.RegisterRoute("Appointments", typeof(AppointmentsPage));
		Routing.RegisterRoute("//Main/Calendar", typeof(MonthView));
		Routing.RegisterRoute("//Main/Employers", typeof(Employers));
		Routing.RegisterRoute("//Main/Employers/AddEmployer", typeof(AddEmployerView));
		Routing.RegisterRoute("//Main/Employers/Projects", typeof(Projects));
		Routing.RegisterRoute("//Main/Employers/Projects/ProjectTimeEntries", typeof(ProjectTimeEntries));
    }
}
