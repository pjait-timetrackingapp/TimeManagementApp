namespace TmaLib
{
    public class UserInputAddProject
    {
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }

        public UserInputAddProject(int id, string name)
        {
            ProjectId = id;
            ProjectName = name;
        }
    }
}
