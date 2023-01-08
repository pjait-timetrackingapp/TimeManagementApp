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
            Assert.Equal(3, _sut?.Employers?.FirstOrDefault()?.Id);
        }

        [Fact]  
        public void AddEmployerNameIsNullTest()
        {
            //Arrange
            var userInput = new UserInputAddEmployer(4, null);

            //Assert
            var exception = Assert.Throws<System.ArgumentException>(() => _sut.AddEmployer(userInput));
            Assert.Equal("Name cannot be null", exception.Message);
        }

        [Fact]
        public void AddEmployerNameIsEmptyTest() 
        {
            //Arrange 
            var userInput = new UserInputAddEmployer(5, "  ");

            //Assert
            var exception = Assert.Throws<System.ArgumentException>(() => _sut.AddEmployer(userInput));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void AddProjectToEmployerIsNotNull()
        {
            //Arrange
            var userInputAddEmployer = new UserInputAddEmployer(1, "Employer1");
            _sut.AddEmployer(userInputAddEmployer);
            var userInputAddProject = new UserInputAddProject(1, "ProjectName1");
            string employerName = "Employer1";
            
            //Act
            _sut.AddProjectToEmployer(employerName, userInputAddProject);

            //Assert
            var employerHasProjectTest = _sut.Employers?.FirstOrDefault()?.Projects?.FirstOrDefault();
            //var employerHasProjectTest = _sut.Employers.FirstOrDefault().Projects.FirstOrDefault();
            Assert.NotNull(employerHasProjectTest);
        }

        [Fact]
        public void AddProjectAddIdTest()
        {
            //Arrange
            var userInputAddEmployer = new UserInputAddEmployer(2, "Employer2");
            var userInputAddProject = new UserInputAddProject(2, "ProjectName2");
            string employerName = "Employer2";
            //Act
            _sut.AddEmployer(userInputAddEmployer);
            _sut.AddProjectToEmployer(employerName, userInputAddProject);

            //Assert
            var projectWithId = _sut.Employers?.FirstOrDefault()?.Projects?.FirstOrDefault()?.projectId;
            Assert.Equal(2, projectWithId);
        }

        [Fact]
        public void AddProjectAddNameTest()
        {
            //Arrange
            var userInputAddEmployer = new UserInputAddEmployer(2, "Employer2");
            var userInputAddProject = new UserInputAddProject(2, "ProjectName2");
            string employerName = "Employer2";
            //Act
            _sut.AddEmployer(userInputAddEmployer);
            _sut.AddProjectToEmployer(employerName, userInputAddProject);

            //Assert
            var projectWithId = _sut.Employers?.FirstOrDefault()?.Projects?.FirstOrDefault()?.projectName;
            Assert.Equal("ProjectName2", projectWithId);
        }
        [Fact]
        public void AddProjectNameIsNullTest()
        {
            //Arrange
            var userInputAddEmployer = new UserInputAddEmployer(3, "Employer3");
            var userInputAddProject = new UserInputAddProject(3, null);
            string employerName = "Employer3";
            //Act
            _sut.AddEmployer(userInputAddEmployer);
            //Assert
            var exception = Assert.Throws<System.ArgumentException>(() => _sut.AddProjectToEmployer(employerName, userInputAddProject));
            Assert.Equal("Name cannot be null", exception.Message);
        }

        [Fact]
        public void AddProjectNameIsEmpty()
        {
            //Arrange
            var userInputAddEmployer = new UserInputAddEmployer(4, "Employer4");
            var userInputAddProject = new UserInputAddProject(4, "  ");
            string employerName = "Employer4";

            //Assert

            var exception = Assert.Throws<System.ArgumentException>(() => _sut.AddProjectToEmployer(employerName, userInputAddProject));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void AddEmployer_WhenInputProvided_ShouldAddEMployerToDatabase()
        {
            //Arrange
            var userInputAddEmployer = new UserInputAddEmployer(1, "Employer");
            var employerId = 1;
            //Act
            _sut.AddEmployer(userInputAddEmployer);
            //Assert
            Assert.Equal("Employer" , _sut.ReturnEmployerFromDataBase(employerId).Name);
        }
    }
}
