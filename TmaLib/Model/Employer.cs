namespace TmaLib.Model
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string Name { get; set; }

        public List<Project> Projects = new();

        public Employer()
        {
            // Some libs may need an empty ctor to perform some (un)marshalling work
        }

        public Employer(UserInputAddEmployer userInputAddEmployer)
        {
            EmployerId = userInputAddEmployer.Id;
            Name = userInputAddEmployer.Name;
        }
    }    
}
