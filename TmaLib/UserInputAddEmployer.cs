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
        public long _id;
        public string _name;
        public UserInputAddEmployer(long Id, string name)
        {
            _id = Id;
            _name = name;

        }
    }
}
