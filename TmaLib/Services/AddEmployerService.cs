using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Model;
using Xunit.Sdk;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public Employer employer;
        public List<Employer> Employers = new List<Employer>();
        

        public AddEmployerService(UserInputAddEmployer userInput)
        {
            employer = new Employer(userInput);
            employer.Id = userInput._id;
            employer.Name = userInput._name;
        }

        public void AddEmployer(Employer employer)
        {
            Employers.Add(employer);
        }

    }
}
