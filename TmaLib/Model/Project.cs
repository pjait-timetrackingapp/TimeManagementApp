using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmaLib.Model
{
    public class Project
    {
        public long projectId { get; set; }
        public string projectName { get; set; }

        public Project()
        {

        }
        public Project(UserInputAddProject userInputAddProject)
        {
            projectId = userInputAddProject.projectId;
            projectName = userInputAddProject.projectName;
        }
    }
}
