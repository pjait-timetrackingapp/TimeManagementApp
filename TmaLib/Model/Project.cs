namespace TmaLib.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        
        public List<TimeEntry> TimeEntries = new();

        public Project()
        {
        }

        public Project(UserInputAddProject userInputAddProject) : base()
        {
            ProjectId = userInputAddProject.ProjectId;
            ProjectName = userInputAddProject.ProjectName;
        }

        public void Add(TimeEntry timeEntry)
        {
            TimeEntries.Add(timeEntry);
        }
    }
}
