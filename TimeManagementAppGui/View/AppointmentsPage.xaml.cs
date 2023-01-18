using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class AppointmentsPage : ContentPage
{
    private readonly SchedulerDataViewModel _schedulerDataViewModel;

    public AppointmentsPage(SchedulerDataViewModel vm)
	{
        BindingContext = vm;
        _schedulerDataViewModel = vm;
		
        InitializeComponent();

        Page.Title = vm.TimeboxDate.ToLongDateString();
        
        collectionView.ItemsSource = vm.GetSelectedDaySchedulerEntries(vm.TimeboxDate);

        vm.ViewChanged += Vm_ViewChanged;
    }

    private void Vm_ViewChanged(object sender, EventArgs e)
    {
        collectionView.ItemsSource = _schedulerDataViewModel.GetSelectedDaySchedulerEntries(_schedulerDataViewModel.TimeboxDate);
    }
}