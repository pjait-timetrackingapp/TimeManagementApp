using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Model;
using TmaLib.Repository;

namespace TimeManagementAppGui.ViewModel
{
    public partial class AddTimeEntryViewModel : ViewModelBase
    {
        private string _time;
        private string _description;
        private DateTime _date = DateTime.Now;
        [ObservableProperty]
        private Project _selectedProject;

        public Employer SelectedEmployer 
        { 
            get => _selectedEmployer; 
            set
            {
                try
                {
                    if (_selectedEmployer != value)
                    {
                        _selectedEmployer = value;
                        OnPropertyChanged(nameof(SelectedEmployer));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private Employer _selectedEmployer;

        public string Time { get => _time; set => SetProperty(ref _time, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }

        public List<Employer> Employers { get => _employerRepository.GetAll(); }
        public List<Project> Projects
        {
            get; set;
        }

        public ICommand AddItem { get; }

        private readonly SchedulerDataViewModel _schedulerData;
        private readonly IEmployerRepository _employerRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITimeEntryRepository _timeEntryRepository;

        public AddTimeEntryViewModel(SchedulerDataViewModel schedulerData, IDialogService dialogService, INavigationService navigationService, IEmployerRepository employerRepository, IProjectRepository projectRepository, ITimeEntryRepository timeEntryRepository) : base(dialogService, navigationService)
        {
            AddItem = new AsyncRelayCommand(Add);
            _schedulerData = schedulerData;
            _employerRepository = employerRepository;
            _projectRepository = projectRepository;
            _timeEntryRepository = timeEntryRepository;

            PropertyChanged += AddTimeEntryViewModel_PropertyChanged; ;
        }

        private void AddTimeEntryViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedEmployer))
            {
                Projects = _projectRepository.GetAllByEmployerId(SelectedEmployer.Id);
                OnPropertyChanged(nameof(Projects));
            }
        }

        private async Task Add()
        {
            if (SelectedEmployer?.Id is null || SelectedProject?.Id is null)
            {
                await DialogService.ShowAlertAsync("Sprawdź poprawność wszystkich pól", "Coś poszło nie tak", "Ok");
                return;
            }
            var entry = new TimeEntry(Date, Description, TimeSpan.Parse(Time), SelectedProject.Id);
            var addedEntry = _timeEntryRepository.Add(entry);
            _schedulerData.TimeEntries.Add(new SchedulerEntry()
            {
                LabelId = (addedEntry.ProjectId % 10) + 1,
                TimeEntry = addedEntry,
                ProjectId = addedEntry.ProjectId,
                EntryId = addedEntry.Id,
            });
            _timeEntryRepository.SaveChanges();
        }
    }
}
