using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Model;

namespace TmaLib.Services
{
    public class AddEmployerService : IAddEmployerService
    {
        public List<Employer> Employers = new List<Employer>();
        public Employer Employer { get; set; }

        public AddEmployerService(UserInputAddEmployer UserInput)
        {
            Employer.Id = UserInput._id;
            Employer.Name = UserInput._name;
        }

        public void AddEmployer()
        {
            Employers.Add(Employer);
        }

    }
}
