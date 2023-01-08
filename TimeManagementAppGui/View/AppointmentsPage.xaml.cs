using DevExpress.Maui.Scheduler;

namespace TimeManagementAppGui.View;

public partial class AppointmentsPage : ContentPage
{
    public IEnumerable<AppointmentItem> Appointments { get; }
	public AppointmentsPage(IEnumerable<AppointmentItem> appointments)
	{
		InitializeComponent();
        Appointments = appointments;

        collectionView.ItemsSource = Appointments;
    }

}