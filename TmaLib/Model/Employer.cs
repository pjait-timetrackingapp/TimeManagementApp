using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmaLib.Model
{
    public class Employer
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Employer(UserInputAddEmployer userInputAddEmployer)
        {
            Id = userInputAddEmployer._id;
            Name= userInputAddEmployer._name;

        }

    }

    
}
