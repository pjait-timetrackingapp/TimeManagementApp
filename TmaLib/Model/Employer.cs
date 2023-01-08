using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TmaLib.Model
{
    [Table("Pracodawca")]
    public class Employer
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects = new List<Project>();

        public Employer(UserInputAddEmployer userInputAddEmployer)
        {
            Id = userInputAddEmployer.Id;
            Name= userInputAddEmployer.Name;
        }
    }    
}
