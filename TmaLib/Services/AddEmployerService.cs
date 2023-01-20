using TmaLib.Model;
using TmaLib.Repository;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public List<Employer> Employers = new List<Employer>();
        private readonly IEmployerRepository _employerRepository;

        public AddEmployerService(IEmployerRepository employerRepository, IProjectRepository projectRepository, ITimeEntryRepository timeEntryRepository)
        {
            _employerRepository = employerRepository;

            var employer = new Employer(new UserInputAddEmployer("John Doe"));
            var employerData = _employerRepository.Add(employer);
            var project1 = new Project() { ProjectName = "Mission BYTpossible", Employer = employerData, EmployerId = employerData.Id };
            var project2 = new Project() { ProjectName = "Nauka Japońskiego", Employer = employerData, EmployerId = employerData.Id };
            var project3 = new Project() { ProjectName = "Nauka Chińskiego", Employer = employerData, EmployerId = employerData.Id };
            var project4 = new Project() { ProjectName = "Nauka Angielskiego", Employer = employerData, EmployerId = employerData.Id };
            
            var pdata1 = projectRepository.Add(project1);
            var pdata2 = projectRepository.Add(project2);
            var pdata3 = projectRepository.Add(project3);
            var pdata4 = projectRepository.Add(project4);

            var te1 = new TimeEntry() { DateStarted = DateTime.Today.AddHours(8), Description = "Projekt na BYT 🙂", Duration = TimeSpan.FromHours(3.5), Project = pdata1, ProjectId = pdata1.Id };
            var te2 = new TimeEntry() { DateStarted = DateTime.Today.AddDays(-2), Description = "Raport z testów", Duration = TimeSpan.FromHours(8), Project = pdata2, ProjectId = pdata2.Id };
            timeEntryRepository.Add(te1);
            timeEntryRepository.Add(te2);
            _employerRepository.SaveChanges();
        }
        public Employer MakeEmployer(UserInputAddEmployer userInput)
        {
            return new Employer(userInput);
        }

        public void AddEmployer(UserInputAddEmployer userInput)
        {
            if(userInput.Name == null)
            {
                throw new ArgumentException("Name cannot be null");
            }
            if(userInput.Name.Trim() == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            var employer = MakeEmployer(userInput);
            _employerRepository.Add(employer);
            _employerRepository.SaveChanges();
        }

        public Project MakeProject(UserInputAddProject userInputAddProject)
        {
            return new Project(userInputAddProject);
        }

        public void AddProjectToEmployer(string EmployerName, UserInputAddProject userInputAddProject)
        {
            var project = MakeProject(userInputAddProject);

            if (userInputAddProject.ProjectName == null)
            {
                throw new ArgumentException("Name cannot be null");
            }
            if (userInputAddProject.ProjectName.Trim() == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            foreach (var employer in Employers)
            {
                if(employer.Name == EmployerName)
                {                   
                    employer.Projects.Add(project);
                }
            }
        }

        public async Task<Employer> Get(long employerId)
        {
            var employer = Employers.FirstOrDefault(x => x.Id == employerId);

            if (employer is null)
            {
                throw new KeyNotFoundException("No such employer");
            }

            return await Task.FromResult(employer);
        }

        public async Task<IList<Employer>> GetAll()
        {
            return await Task.FromResult(Employers);
        }

        public async Task Add(TimeEntry timeEntry, long employerId, long projectId)
        {
            var employer = await Get(employerId);
            var project = employer.Projects.FirstOrDefault(x => x.Id == projectId);

            if (project is null)
            {
                throw new KeyNotFoundException("No such project");
            }

            project.Add(timeEntry);
        }

        public void RemoveTimeEntry(long entryId, long projectId, long employerId)
        {
            var employer = Employers.FirstOrDefault(e => e.Id == employerId);
            var projectEntries = employer?.Projects.FirstOrDefault(p => p.Id == projectId)?.TimeEntries;
            var entryToRemove = projectEntries?.FirstOrDefault(te => te.Id == entryId);
            if (!projectEntries?.Remove(entryToRemove) ?? true)
            {
                throw new ArgumentException("Entry not found");
            }
        }
    }
}
