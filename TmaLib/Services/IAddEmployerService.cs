using TmaLib.Model;

namespace TmaLib.Services
{
    public interface IAddEmployerService
    {
        void AddEmployer(UserInputAddEmployer userInput);
        void AddProjectToEmployer(string EmployerName, UserInputAddProject userInputAddProject);
    }
}