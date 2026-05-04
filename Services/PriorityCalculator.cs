using PriorityDashboard.Models;

namespace PriorityDashboard.Services
{
    public static class PriorityCalculator
    {
        public static int Calculate(TaskItem task)
        {
            int daysLeft = (task.Deadline - DateTime.Now).Days;

            int deadlineScore = daysLeft switch
            {
                <= 1 => 40,
                <= 3 => 30,
                <= 7 => 20,
                <= 14 => 10,
                _ => 5
            };

            int effortScore = (int)task.Effort * 10;
            int importanceScore = (int)task.Importance * 10;

            int total = deadlineScore + effortScore + importanceScore;

            return Math.Min(total, 100);
        }
    }
}