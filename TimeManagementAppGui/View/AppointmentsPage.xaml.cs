using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class AppointmentsPage : ContentPage
{
	public AppointmentsPage(SchedulerDataViewModel vm)
	{
        BindingContext = vm;
		InitializeComponent();


        //To fix - deleted items stay in Timebox Appointments page.
        collectionView.ItemsSource = vm.GetSelectedDaySchedulerEntries(vm.TimeboxDate);
        Page.Title = vm.TimeboxDate.ToLongDateString();
    }
}