using TmaLib.Model;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public List<Employer> Employers = new List<Employer>();
        public List<Project> EmployerProjects = new List<Project>();

        private void ApplyGuiTestSetup()
        {
            var employer = new Employer(new UserInputAddEmployer(1, "John Doe"))
            { Projects = new List<Project>() { new Project() { projectId = 1, projectName = "Mission BYTpossible" }, new Project() { projectId = 2, projectName = "Nauka japońskiego", } } };
            employer.Projects[0].timeEntries.Add(new TimeEntry() { DateStarted = DateTime.Today, Description = "Projekt na BYT 🙂", Duration = TimeSpan.FromHours(3.5) });
            employer.Projects[0].timeEntries.Add(new TimeEntry() { DateStarted = DateTime.Today.AddDays(-2), Description = "Urlop", Duration = TimeSpan.FromHours(8) });
            Employers.Add(employer);
        }

        public AddEmployerService()
        {
            ApplyGuiTestSetup();
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
            Employers.Add(employer);          
        }

        public Project MakeProject(UserInputAddProject userInputAddProject)
        {
            return new Project(userInputAddProject);
        }

        public void AddProjectToEmployer(string EmployerName, UserInputAddProject userInputAddProject)
        {
            var project = MakeProject(userInputAddProject);

            if (userInputAddProject.projectName == null)
            {
                throw new ArgumentException("Name cannot be null");
            }
            if (userInputAddProject.projectName.Trim() == string.Empty)
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
            var project = employer.Projects.FirstOrDefault(x => x.projectId == projectId);

            if (project is null)
            {
                throw new KeyNotFoundException("No such project");
            }

            project.Add(timeEntry);
        }
    }
}
