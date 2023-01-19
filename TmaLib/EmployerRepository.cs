using Microsoft.EntityFrameworkCore;
using TmaLib.Model;
using TmaLib.Persistance;

namespace TmaLib
{
    public class EmployerRepository : RepositoryBase, IEmployerRepository
    {
        private readonly TaskContext _taskContext;

        public EmployerRepository(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task<List<Employer>> GetAll()
        {
            return await _taskContext.Employers.ToListAsync();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<Employer> GetById(int id)
        {
            var result = await _taskContext.Employers.FindAsync(id);

            if (result == null)
            {
                throw new KeyNotFoundException("Unable to find employer with the given ID");
            }

            return result;
        }

        public Employer Add(Employer employer)
        {
            return _taskContext.Employers.Add(employer).Entity;
        }

        public Employer Remove(Employer employer)
        {
            return _taskContext.Employers.Remove(employer).Entity;
        }

        public Employer Update(Employer employer)
        {
            return _taskContext.Update(employer).Entity;
        }
    }
}
