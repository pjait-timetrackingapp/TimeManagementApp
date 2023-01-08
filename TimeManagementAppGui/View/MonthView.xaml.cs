namespace TimeManagementAppGui;

public partial class MonthView : ContentView
{
    public MonthView()
	{
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