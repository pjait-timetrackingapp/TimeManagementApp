using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Services;
using TmaLib.Model;

namespace TmaLib.Test.ServicesTests
{
    public class AddEmployerServiceTest
    {
        private readonly AddEmployerService _sut;

        public AddEmployerServiceTest()
        {
            _sut = new AddEmployerService();
        }

        [Fact]
        public void AddEmployerTest()
        {
            _sut.AddEmployer(1, "employer1");
        }

    }
}
