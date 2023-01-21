using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Model;
using TmaLib.Repository;
using TmaLib.Services;

namespace TimeManagementAppGui.ViewModel
{
    public partial class SchedulerDataViewModel : ViewModelBase
    {
        private readonly IAddEmployerService _addEmployerService;
        private readonly ITimeEntryRepository _timeEntryRepository;
        private readonly IEmployerRepository _employerRepository;
        [ObservableProperty]
        public ObservableCollection<SchedulerEntry> timeEntries;
        
        public ObservableCollection<SchedulerEntry> SelectedAppointments { get; set; }
        
        [ObservableProperty]
        private SchedulerEntry selectedTimeEntry;
        
        public DateTime TimeboxDate { get; internal set; }
        public bool IsFabVisible { get => selectedTimeEntry != null; }
        
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand RemoveSelectedItem { get; set; }

        public event EventHandler ViewChanged;

        public SchedulerDataViewModel(
            IDialogService dialogService,
            INavigationService navigationService,
            IAddEmployerService addEmployerService,
            ITimeEntryRepository timeEntryRepository,
            IEmployerRepository employerRepository) : base(dialogService, navigationService)
        {
            _addEmployerService = addEmployerService;
            _timeEntryRepository = timeEntryRepository;
            _employerRepository = employerRepository;
            TimeEntries = new ObservableCollection<SchedulerEntry>();
            SelectedAppointments = new ObservableCollection<SchedulerEntry>();

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
                    var entryId = selectedTimeEntry.TimeEntry.Id;
                    _timeEntryRepository.Remove(selectedTimeEntry.TimeEntry);
                    _timeEntryRepository.SaveChanges();
                    SelectedAppointments.Remove(SelectedTimeEntry);
                    var item = TimeEntries.FirstOrDefault(x => x.TimeEntry.Id == entryId);
                    TimeEntries.Remove(item);
                    SelectedTimeEntry = null;
                    OnPropertyChanged(nameof(IsFabVisible));
                }
            }
            catch (ArgumentException)
            {
            }
        }

        public void InitializeCollection()
        {
            var entries = _timeEntryRepository.GetAll();
            TimeEntries = Convert(entries);
        }

        public void UpdateSelectedAppointments()
        {
            var items = TimeEntries.Where(te => te.TimeEntry.DateStarted.Date == TimeboxDate.Date).ToList();
            SelectedAppointments.Clear();
            items.ForEach(i => SelectedAppointments.Add(i));
        }

        public ObservableCollection<SchedulerEntry> Convert(List<TimeEntry> entries)
        {
            ObservableCollection<SchedulerEntry> timeEntries = new();
            entries.ForEach(te =>
            {
                timeEntries.Add(new SchedulerEntry()
                {
                    LabelId = te.ProjectId % 10 + 1,
                    TimeEntry = te,
                    ProjectId = te.ProjectId,
                    EntryId = te.Id,
                });
            });

            return timeEntries;
        }

        public async Task DisplayDetailsPage(DateTime date)
        {
            TimeboxDate = date;
            var data = _timeEntryRepository.GetByDate(date.Date);
            SelectedAppointments = Convert(data);
            await NavigationService.NavigateToAsync("Appointments");
        }

        public List<SchedulerEntry> GetSelectedDayEntries(DateTime date)
        {
            var data = _timeEntryRepository.GetByDate(date.Date);
            var schedulerEntries = Convert(data).ToList();
            return schedulerEntries;
        }
    }

    public class SchedulerEntry
    {
        public int LabelId { get; set; }
        public long EmployerId { get; set; }
        public long ProjectId { get; set; }
        public long EntryId { get; set; }
        public string Duration { get => TimeEntry.Duration.ToString(); }
        public string DateStarted { get => TimeEntry.DateStarted.ToString("dddd, dd MMMM yyyy HH:mm", CultureInfo.CreateSpecificCulture("pl-PL")); }
        public TimeEntry TimeEntry { get; set; }
    }
}
