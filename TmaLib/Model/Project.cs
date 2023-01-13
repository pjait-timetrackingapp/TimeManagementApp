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
        public List<TimeEntry> timeEntries { get; set; }

        public Project()
        {
            timeEntries = new List<TimeEntry>();
        }
        public Project(UserInputAddProject userInputAddProject) : base()
        {
            projectId = userInputAddProject.projectId;
            projectName = userInputAddProject.projectName;
        }

        public void Add(TimeEntry timeEntry)
        {
            timeEntries.Add(timeEntry);
        }
    }
}
