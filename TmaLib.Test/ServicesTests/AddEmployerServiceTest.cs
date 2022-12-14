using TmaLib.Services;


namespace TmaLib.Test.ServicesTests
{
    public class AddEmployerServiceTest
    {
        private AddEmployerService _sut;

        public AddEmployerServiceTest()
        {          
            _sut = new AddEmployerService();
        }

        [Fact]
        public void AddEmployerIsNullTest()
        {
            //Arrange
            var userInput = new UserInputAddEmployer(1, "testname1");
            //Act 
            _sut.AddEmployer(userInput);

            //Assert
            var employerTest = _sut.Employers.FirstOrDefault();
            Assert.NotNull(employerTest);            
        }

        [Fact]
        public void AddEmployerAddIDTest()
        {
            //Arrange
             var userInput = new UserInputAddEmployer(2, "testname2");
            //Act
            _sut.AddEmployer(userInput);

            //Assert
            var employerTest = _sut.Employers?.FirstOrDefault()?.Name;
            Assert.Equal("testname2", employerTest);
        }

        [Fact]
        public void AddEmployerAddNameTest()
        {
            //Arrange
            var userInput = new UserInputAddEmployer(3, "testname3");
            //Act
            _sut.AddEmployer(userInput);

            //Assert
            var employerTest = _sut.Employers.FirstOrDefault();
            Assert.Equal(3, _sut?.Employers?.FirstOrDefault()?.Id);
        }
    }
}
