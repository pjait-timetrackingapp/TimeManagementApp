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
}