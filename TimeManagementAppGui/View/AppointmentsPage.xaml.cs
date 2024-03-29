using System.Globalization;
using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class AppointmentsPage : ContentPage
{
    private readonly SchedulerDataViewModel _vm;

    public AppointmentsPage(SchedulerDataViewModel vm)
    {
        BindingContext = vm;
        _vm = vm;

        InitializeComponent();

        Page.Title = vm.TimeboxDate.ToString("ddd d MMMM", CultureInfo.CreateSpecificCulture("pl-PL"));
        collectionView.ItemsSource = vm.SelectedAppointments;

        vm.SelectedAppointments.CollectionChanged += TimeEntries_CollectionChanged;
        vm.TimeEntries.CollectionChanged += TimeEntries_CollectionChanged;
    }

    private void TimeEntries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        collectionView.RefreshData();
    }
}