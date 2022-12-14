using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Model;

namespace TmaLib
{
    public class UserInputAddEmployer
    {
        public long Id;
        public string Name;
        public UserInputAddEmployer(long Id, string name)
        {
            this.Id = Id;
            Name = name;
        }
    }
}
