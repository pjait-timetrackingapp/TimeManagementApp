using DevExpress.Maui.Scheduler.Internal;
using System.Collections.ObjectModel;
using TmaLib.Services;

namespace TimeManagementAppGui.ViewModel
{
    public class SchedulerDataViewModel
    {
        public ObservableCollection<SchedulerEntry> TimeEntries { get; private set; }
        public IAddEmployerService _addEmployerService { get; }

        public SchedulerDataViewModel(IAddEmployerService addEmployerService)
        {
            _addEmployerService = addEmployerService;

            TimeEntries = new ObservableCollection<SchedulerEntry>();
            InitializeCollection();
        }

        public async Task InitializeCollection()
        {
            TimeEntries.Clear();
            var randomizer = new Random();
            var employers = await _addEmployerService.GetAll();
            employers.ForEach(e =>
            {
                e.Projects.ForEach(p =>
                {
                    var labelId = randomizer.Next(1, 10);
                    p.timeEntries.ForEach(te =>
                    {
                        TimeEntries.Add(new SchedulerEntry()
                        {
                            LabelId = labelId,
                            Start = te.DateStarted,
                            End = te.DateStarted.Add(te.Duration),
                            Subject = te.Description
                        });
                    });
                });
            });
        }
    }

    public class SchedulerEntry
    {
        public int LabelId { get; set; }
        public string Subject { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
