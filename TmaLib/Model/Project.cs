namespace TmaLib.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public List<TimeEntry> TimeEntries = new();

        public Project()
        {
        }

        public Project(UserInputAddProject userInputAddProject) : base()
        {
            EmployerId = userInputAddProject.EmployerId;
            ProjectName = userInputAddProject.ProjectName;
        }

        public void Add(TimeEntry timeEntry)
        {
            TimeEntries.Add(timeEntry);
        }
    }
}
