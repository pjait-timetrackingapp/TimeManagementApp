using TmaLib.Model;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public List<Employer> Employers = new List<Employer>();
        public List<Project> EmployerProjects = new List<Project>();

        public AddEmployerService()
        {

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
            foreach (var employer in Employers)
            {
                if(employer.Name == EmployerName)
                {                   
                    employer.Projects.Add(project);
                }
            }
        }
    }
}
