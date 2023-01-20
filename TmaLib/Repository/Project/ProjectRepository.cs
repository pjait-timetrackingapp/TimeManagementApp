using Microsoft.EntityFrameworkCore;
using TmaLib.Model;
using TmaLib.Persistance;
using System.Linq;

namespace TmaLib.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskContext _taskContext;

        public ProjectRepository(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task SaveChanges()
        {
            await _taskContext.SaveChangesAsync();
        }

        public List<Project> GetAll()
        {
            return _taskContext.Projects.ToList();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<Project> GetById(int id)
        {
            var result = await _taskContext.FindAsync<Project>(id);

            if (result == null)
            {
                throw new KeyNotFoundException("Unable to find employer with the given ID");
            }

            return result;
        }

        public Project Add(Project project)
        {
            return _taskContext.Add(project).Entity;
        }

        public Project Remove(Project project)
        {
            return _taskContext.Remove(project).Entity;
        }

        public Project Update(Project project)
        {
            return _taskContext.Update(project).Entity;
        }

        public List<Project> GetAllByEmployerId(int id)
        {
            return _taskContext.Projects.Where(p => p.EmployerId == id).ToList();
        }
    }
}
