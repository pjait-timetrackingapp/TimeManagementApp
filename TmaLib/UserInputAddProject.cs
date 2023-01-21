namespace TmaLib
{
    public class UserInputAddProject
    {
        public string ProjectName { get; set; }
        public int EmployerId { get; set; }

        public UserInputAddProject(string name, int employerId)
        {
            ProjectName = name;
            EmployerId = employerId;

        }
    }
}
