using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmaLib.Services;
using TmaLib.Model;
using System.Security.Cryptography.X509Certificates;

namespace TmaLib.Test.ServicesTests
{
    public class AddEmployerServiceTest
    {
        private readonly AddEmployerService _sut;
        private readonly UserInputAddEmployer _userInputAddEmployer;
        private readonly Employer _employer;

        public AddEmployerServiceTest()
        {
            _userInputAddEmployer = new UserInputAddEmployer(1, "TestName1");
            _employer = new Employer(_userInputAddEmployer); 
            _sut = new AddEmployerService(_userInputAddEmployer);
            
        }

        [Fact]
        public void AddEmployerIsNullTest()
        {
            //Arrange

            //Act
            _sut.AddEmployer(_employer);

            //Assert

            var employerTest = _sut.Employers.FirstOrDefault();
            Assert.NotNull(employerTest);
            
            
            
        }

        [Fact]
        public void AddEmployerAddIDTest()
        {
            //Arrange

            //Act
            _sut.AddEmployer(_employer);

            //Assert
            var employerTest = _sut.Employers.FirstOrDefault().Name;
            Assert.Equal("TestName1", employerTest);

        }

        [Fact]
        public void AddEmployerAddNameTest()
        {
            //Arrange

            //Act
            _sut.AddEmployer(_employer);

            //Assert
            var employerTest = _sut.Employers.FirstOrDefault();
            Assert.Equal(1, _sut.Employers.FirstOrDefault().Id);

        }

    }
}
