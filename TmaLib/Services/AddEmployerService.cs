using SQLite;
using TmaLib.Model;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public List<Employer> Employers = new List<Employer>();
        public List<Project> EmployerProjects = new List<Project>();
        //var dbPath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestData.db");
        //var db = new SQLiteConnection(dbPath);

        public AddEmployerService()
        {
            CreateDatabase();
        }
        public Employer MakeEmployer(UserInputAddEmployer userInput)
        {
            return new Employer(userInput);
        }

        public void CreateDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestData.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Employer>();
            db.CreateTable<Project>();
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
    }
}
