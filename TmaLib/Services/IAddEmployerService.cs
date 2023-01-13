using TmaLib.Model;

namespace TmaLib.Services
{
    public interface IAddEmployerService
    {
        void AddEmployer(UserInputAddEmployer userInput);
        void AddProjectToEmployer(string EmployerName, UserInputAddProject userInputAddProject);
        Task<Employer> Get(long employerId);
        Task Add(TimeEntry timeEntry, long employerId, long projectId);
    }
}