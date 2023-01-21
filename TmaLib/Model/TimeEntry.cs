namespace TmaLib.Model
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DateStarted { get; set; }
        public string Description { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public TimeEntry() { }

        public TimeEntry(DateTime start, string description, TimeSpan duration, int projectId)
        {
            Description = description;
            DateStarted = start;
            Duration = duration;
            ProjectId = projectId;
        }

        /// <exception cref="ArgumentException"></exception>
        public TimeEntry(DateTime start, string description, string duration)
        {
            Description = description;
            DateStarted = start;
            Duration = TimeSpan.TryParse(duration, out var activityDuration)
                ? activityDuration
                : throw new ArgumentException("Invalid duration format");
        }

    }
}
