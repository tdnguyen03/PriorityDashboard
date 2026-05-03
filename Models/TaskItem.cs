namespace PriorityDashboard.Models
{
    public enum Level
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public Level Effort { get; set; }
        public Level Importance { get; set; }
        public int Score { get; set; }

        public string SubtasksRaw { get; set; } = "";
    }
}