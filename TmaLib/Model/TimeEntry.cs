namespace TmaLib.Model
{
    public class TimeEntry
    {
        public long Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DateStarted { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
