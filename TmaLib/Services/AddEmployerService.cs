using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Model;
using Xunit.Sdk;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
    
        public List<Employer> Employers = new List<Employer>();
        
        public AddEmployerService()
        {
       
        }
        public Employer MakeEmployer(UserInputAddEmployer userInput)
        {
            return new Employer(userInput);
        }

        public void AddEmployer(UserInputAddEmployer userInput)
        {
            var employer = MakeEmployer(userInput);
            Employers.Add(employer);
        }
    }
}
