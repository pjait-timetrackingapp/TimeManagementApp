using Microsoft.EntityFrameworkCore;
using TmaLib.Model;
using TmaLib.Persistance;

namespace TmaLib.Repository
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly TaskContext _taskContext;

        public TimeEntryRepository(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task SaveChanges()
        {
            await _taskContext.SaveChangesAsync();
        }

        public List<TimeEntry> GetAll()
        {
            return _taskContext.TimeEntries.ToList();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<TimeEntry> GetById(int id)
        {
            var result = await _taskContext.FindAsync<TimeEntry>(id);

            if (result == null)
            {
                throw new KeyNotFoundException("Unable to find TimeEntry with the given ID");
            }

            return result;
        }

        public List<TimeEntry> GetByDate(DateTime date)
        {
            return _taskContext.TimeEntries.Where(te => te.DateStarted.Date == date.Date).ToList();
        }

        public TimeEntry Add(TimeEntry employer)
        {
            return _taskContext.Add(employer).Entity;
        }

        public TimeEntry Remove(TimeEntry employer)
        {
            return _taskContext.Remove(employer).Entity;
        }

        public TimeEntry Update(TimeEntry employer)
        {
            return _taskContext.Update(employer).Entity;
        }
    }
}
