using TmaLib.Model;

namespace TmaLib.Services
{
    internal interface IAddProjectService
    {
        void AddProject(UserInputAddProject userInputAddProject);
        Project MakeProject(UserInputAddProject userInputAddProject);
    }
}