using DevExpress.Maui.Scheduler.Internal;
using System.Collections.ObjectModel;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Services;

namespace TimeManagementAppGui.ViewModel
{
    public partial class SchedulerDataViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IAddEmployerService _addEmployerService;

        public ObservableCollection<SchedulerEntry> TimeEntries { get; private set; }
        public DateTime TimeboxDate { get; internal set; }

        public SchedulerDataViewModel(IDialogService dialogService, INavigationService navigationService, IAddEmployerService addEmployerService) : base(dialogService, navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
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

        public void DisplayDetailsPage(DateTime date)
        {
            TimeboxDate = date;
            NavigationService.NavigateToAsync("Appointments");
        }

        public IEnumerable<SchedulerEntry> GetSelectedDaySchedulerEntries(DateTime date)
        {
            return TimeEntries.Where(te => te.Start.Date == date);
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
