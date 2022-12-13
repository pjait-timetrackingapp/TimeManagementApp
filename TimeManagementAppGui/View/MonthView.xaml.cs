namespace TimeManagementAppGui;

public partial class MonthView : ContentView
{
	public string Month => MonthScheduler?.Start.Month.ToString() ?? "Failed to load data";

    public MonthView()
	{
		InitializeComponent();

		MonthScheduler.AppointmentHeight = 200;
		MonthScheduler.Start.Month.ToString();
	}
}