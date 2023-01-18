using TmaLib.Model;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public List<Employer> Employers = new List<Employer>();

        private void ApplyGuiTestSetup()
        {
            var employer = new Employer(new UserInputAddEmployer(1, "John Doe"))
            { Projects = new List<Project>()
            {
                new Project() { ProjectId = 1, ProjectName = "Mission BYTpossible" },
                new Project() { ProjectId = 2, ProjectName = "Nauka japońskiego", }
            } };
            employer.Projects[0].TimeEntries.Add(new TimeEntry() { TimeEntryId = 1, DateStarted = DateTime.Today.AddHours(8), Description = "Projekt na BYT 🙂", Duration = TimeSpan.FromHours(3.5) });
            employer.Projects[0].TimeEntries.Add(new TimeEntry() { TimeEntryId = 2, DateStarted = DateTime.Today.AddDays(-2), Description = "Raport z testów", Duration = TimeSpan.FromHours(8) });
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
            var employer = Employers.FirstOrDefault(x => x.EmployerId == employerId);

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
            var project = employer.Projects.FirstOrDefault(x => x.ProjectId == projectId);

            if (project is null)
            {
                throw new KeyNotFoundException("No such project");
            }

            project.Add(timeEntry);
        }

        public void RemoveTimeEntry(long entryId, long projectId, long employerId)
        {
            var employer = Employers.FirstOrDefault(e => e.EmployerId == employerId);
            var projectEntries = employer?.Projects.FirstOrDefault(p => p.ProjectId == projectId)?.TimeEntries;
            var entryToRemove = projectEntries?.FirstOrDefault(te => te.TimeEntryId == entryId);
            if (!projectEntries?.Remove(entryToRemove) ?? true)
            {
                throw new ArgumentException("Entry not found");
            }

            // TODO: Refresh view
        }
    }
}
