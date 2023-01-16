using DevExpress.Maui.Scheduler;
using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class MonthView : ContentPage
{
    public MonthView(SchedulerViewModel vm, SchedulerDataViewModel schedulerData)
	{
        BindingContext = vm;
		InitializeComponent();
        MonthScheduler.BindingContext = schedulerData;
	}

    private void MonthScheduler_Tap(object sender, SchedulerGestureEventArgs e)
    {
        if (e != null)
        {
            var appointments = AppointmentStorage.AppointmentItems.Where(a => a.Start == e.IntervalInfo.Start);
            ShowAppointmentsPage(appointments);
        }
    }

    private void ShowAppointmentsPage(IEnumerable<AppointmentItem> appointments)
    {
        var appEditPage = new AppointmentsPage(appointments);
        Navigation.PushAsync(appEditPage);
    }
}