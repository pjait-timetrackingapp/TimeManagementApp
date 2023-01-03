﻿using TmaLib.Services;


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
    }
}