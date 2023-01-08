using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmaLib
{
    public class UserInputAddProject
    {
        public long projectId;
        public string projectName;

        public UserInputAddProject(long id, string name)
        {
            projectId = id;
            projectName = name;
        }
    }
}
