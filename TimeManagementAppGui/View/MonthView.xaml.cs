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
}