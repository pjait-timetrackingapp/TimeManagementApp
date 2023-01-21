using TmaLib.Model;

namespace TmaLib.Repository
{
    public interface ITimeEntryRepository
    {
        Model.TimeEntry Add(Model.TimeEntry employer);
        List<Model.TimeEntry> GetAll();
        List<TimeEntry> GetByDate(DateTime date);
        Task<Model.TimeEntry> GetById(int id);
        IEnumerable<TimeEntry> GetTimeEntriesForProject(int id);
        Model.TimeEntry Remove(Model.TimeEntry employer);
        Task SaveChanges();
        Model.TimeEntry Update(Model.TimeEntry employer);
    }
}