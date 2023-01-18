using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Scheduler.Internal;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Model;
using TmaLib.Services;

namespace TimeManagementAppGui.ViewModel
{
    public partial class SchedulerDataViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IAddEmployerService _addEmployerService;

        [ObservableProperty]
        public ObservableCollection<SchedulerEntry> timeEntries;
        
        public List<SchedulerEntry> SelectedAppointments { get; set; }
        
        [ObservableProperty]
        private SchedulerEntry selectedTimeEntry;
        
        public DateTime TimeboxDate { get; internal set; }
        public bool IsFabVisible { get => selectedTimeEntry != null; }
        
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand RemoveSelectedItem { get; set; }

        public event EventHandler ViewChanged;

        public SchedulerDataViewModel(IDialogService dialogService, INavigationService navigationService, IAddEmployerService addEmployerService) : base(dialogService, navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _addEmployerService = addEmployerService;

            TimeEntries = new ObservableCollection<SchedulerEntry>();
            SelectedAppointments = new List<SchedulerEntry>();

            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            RemoveSelectedItem = new RelayCommand(RemoveSelectedItemClick);

            InitializeCollection();
        }

        private void OnSelectionChanged()
        {
            OnPropertyChanged(nameof(IsFabVisible));
        }

        private void RemoveSelectedItemClick()
        {
            try
            {
                if (selectedTimeEntry != null)
                {
                    TimeEntries.Remove(SelectedTimeEntry);
                    _addEmployerService.RemoveTimeEntry(selectedTimeEntry.EntryId, selectedTimeEntry.ProjectId, selectedTimeEntry.EmployerId);
                    ViewChanged?.Invoke(this, EventArgs.Empty);
                    SelectedTimeEntry = null;
                    OnPropertyChanged(nameof(IsFabVisible));
                }
            }
            catch (ArgumentException)
            {
            }
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
                            TimeEntry = te,
                            EmployerId = e.Id,
                            ProjectId = p.projectId,
                            EntryId = te.Id,

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
            return TimeEntries.Where(te => te.TimeEntry.DateStarted.Date == date);
        }
    }

    public class SchedulerEntry
    {
        public int LabelId { get; set; }
        public long EmployerId { get; set; }
        public long ProjectId { get; set; }
        public long EntryId { get; set; }
        public TimeEntry TimeEntry { get; set; }
    }
}
