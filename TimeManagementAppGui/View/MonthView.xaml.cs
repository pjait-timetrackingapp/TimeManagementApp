using DevExpress.Maui.Scheduler;
using TimeManagementAppGui.ViewModel;
using TmaLib.Model;

namespace TimeManagementAppGui.View;

public partial class MonthView : ContentPage
{
    private SchedulerDataViewModel vm { get; }
    public MonthView(SchedulerViewModel vm, SchedulerDataViewModel schedulerData)
	{
        BindingContext = vm;
		InitializeComponent();
        MonthScheduler.BindingContext = schedulerData;
        this.vm = schedulerData;

        schedulerData.ViewChanged += SchedulerData_ViewChanged;
    }

    private void SchedulerData_ViewChanged(object sender, EventArgs e)
    {
        vm.InitializeCollection();
    }

    private void MonthScheduler_Tap(object sender, SchedulerGestureEventArgs e)
    {
        if (e != null)
        {
            ShowAppointmentsPage(e.IntervalInfo.Start.Date);
        }
    }

    private void ShowAppointmentsPage(DateTime date)
    {
        vm.DisplayDetailsPage(date);
    }

    protected override void OnAppearing()
    {
        vm.InitializeCollection();
    }
}