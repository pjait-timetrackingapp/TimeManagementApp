using DevExpress.Maui.Scheduler;
using TimeManagementAppGui.View;

namespace TimeManagementAppGui;

public partial class WeekView : ContentView
{
	public WeekView()
	{
		InitializeComponent();
	}

    private void WeekScheduler_Tap(object sender, DevExpress.Maui.Scheduler.SchedulerGestureEventArgs e)
    {
		if (e != null)
		{
            var appointments = AppointmentStorage.AppointmentItems.Where(a => a.Start.ToShortDateString().Equals(e.IntervalInfo.Start.ToShortDateString()));
            ShowAppointmentsPage(appointments);
        }
    }

    private void ShowAppointmentsPage(IEnumerable<AppointmentItem> appointments)
    {
        var appEditPage = new AppointmentsPage(appointments);
        Navigation.PushAsync(appEditPage);
    }
}

