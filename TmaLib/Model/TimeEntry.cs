namespace TmaLib.Model
{
    public class TimeEntry
    {
        public long Id { get; set; } = -1;
        public TimeSpan Duration { get; set; }
        public DateTime DateStarted { get; set; }
        public string Description { get; set; } = string.Empty;

        public TimeEntry() { }

        public TimeEntry(DateTime start, string description, TimeSpan duration)
        {
            Description = description;
            DateStarted = start;
            Duration = duration;
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
