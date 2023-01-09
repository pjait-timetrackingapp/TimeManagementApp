namespace TimeManagementAppGui.ViewModel
{
    public class AddTimeEntryViewModel
    {
        public double Time { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public long ProjectId { get; set; }
        public long EmployerId { get; set; }

        public AddTimeEntryViewModel()
        {
        }
    }
}
