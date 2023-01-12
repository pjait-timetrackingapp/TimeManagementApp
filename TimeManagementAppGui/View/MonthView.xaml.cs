using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class MonthView : ContentPage
{
    public MonthView(SchedulerViewModel vm)
	{
        BindingContext = vm;
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        MonthScheduler.Start = MonthScheduler.Start.AddMonths(1);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new View.AddTimeEntry());
    }
}