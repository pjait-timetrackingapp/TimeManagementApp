using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TimeManagementAppGui
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        public int LabelId { get; set; }
        public string Location { get; set; }
    }

    public class ReceptionDeskData
    {
        public static DateTime BaseDate = DateTime.Today;

        public static string[] TimeEntryNames = { "Create company logo", "H.264-compliant video encoding - consulting",
                                                "TimeEntries pagination", "Implement FIDO authentication",
                                                "OAuth2 integration /w Google services", "Containerize db access service",
                                                "Onboarding /w John", "Big Picture Event Storming with those guys with parcel lockers",
                                                "Meeting deadlines - deliverability assessment /w Linda", "",
                                                "Site Acceptance Tests", "Madeleine Russell",
                                                "Steven Buchanan", "Nancy Davolio",
                                                "Michael Suyama", "Margaret Peacock",
                                                "Janet Leverling", "Ariana Alexander",
                                                "Brad Farkus", "Bart Arnaz",
                                                "Arnie Schwartz", "Billy Zimmer"};
        private static readonly Random rnd = new Random();

        private void SetTimeEntries()
        {
            var entryId = 1;
            var entryIndex = 0;
            DateTime start;
            TimeSpan duration;
            var result = new ObservableCollection<TimeEntry>();
            for (var i = -20; i < 20; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    if (rnd.Next(0, 1) == 0)
                    {
                        var room = rnd.Next(1, 100);
                        start = BaseDate.AddDays(i).AddHours(rnd.Next(8, 17)).AddMinutes(rnd.Next(0, 40));
                        duration = TimeSpan.FromMinutes(rnd.Next(20, 30));
                        result.Add(CreateTimeEntry(entryId, TimeEntryNames[entryIndex],
                                                        start, duration, room));
                        entryId++;
                        entryIndex++;
                        if (entryIndex >= TimeEntryNames.Length - 1)
                        {
                            entryIndex = 1;
                        }
                    }
                }
            }

            TimeEntries = result;
        }

        private TimeEntry CreateTimeEntry(int entryId, string entryName,
                                                    DateTime start, TimeSpan duration, int room)
        {
            var timeEntry = new TimeEntry();
            timeEntry.Id = entryId;
            timeEntry.StartTime = start;
            timeEntry.EndTime = start.Add(duration);
            timeEntry.Subject = entryName;

            // Assign one of the predefined labels to an appointment
            timeEntry.LabelId = rnd.Next(1, 10);

            timeEntry.Location = string.Format("{0}", room);
            return timeEntry;
        }

        public ObservableCollection<TimeEntry> TimeEntries { get; private set; }

        public ReceptionDeskData()
        {
            SetTimeEntries();
        }
    }

    public class ReceptionDeskViewModel : INotifyPropertyChanged
    {
        private readonly ReceptionDeskData data;

        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime StartDate { get { return ReceptionDeskData.BaseDate; } }
        public IReadOnlyList<TimeEntry> MedicalAppointments
        { get => data.TimeEntries; }

        public ReceptionDeskViewModel()
        {
            data = new ReceptionDeskData();
        }

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
