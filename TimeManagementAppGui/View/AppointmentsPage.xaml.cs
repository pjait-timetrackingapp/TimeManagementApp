using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class AppointmentsPage : ContentPage
{
    public DateTime Date { get; set; }
    public IEnumerable<CalendarTimeEntry> TimeEntries { get; }
	public AppointmentsPage(SchedulerDataViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

        collectionView.ItemsSource = vm.GetSelectedDaySchedulerEntries(vm.TimeboxDate);
        Page.Title = vm.TimeboxDate.ToLongDateString();
    }
}