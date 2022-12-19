using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Model;

namespace TmaLib.Services
{
    internal class AddProjectService : IAddProjectService
    {
        public List<Project> Projects = new List<Project>();
        public AddProjectService()
        {

        }

        public Project MakeProject(UserInputAddProject userInputAddProject)
        {
            return new Project(userInputAddProject);
        }

        public void AddProject(UserInputAddProject userInputAddProject)
        {
            Projects.Add(MakeProject(userInputAddProject));
        }
    }
}
