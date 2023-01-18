using Microsoft.EntityFrameworkCore;
using TmaLib.Model;

namespace TmaLib.Persistance
{
    public class TaskContext : DbContext
    {
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }

        public Environment.SpecialFolder DatabaseLocation { get; } = Environment.SpecialFolder.ApplicationData;
        public string DatabaseName { get; } = "taskapp.db";
        public string DbPath { get; }

        public TaskContext()
        {
            var path = Environment.GetFolderPath(DatabaseLocation);
            DbPath = Path.Join(path, DatabaseName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
