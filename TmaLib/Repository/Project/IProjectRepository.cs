using TmaLib.Model;

namespace TmaLib.Repository
{
    public interface IProjectRepository
    {
        Project Add(Project project);
        List<Project> GetAll();
        List<Project> GetAllByEmployerId(int id);
        Task<Project> GetById(int id);
        Project Remove(Project project);
        Task SaveChanges();
        Project Update(Project project);
    }
}