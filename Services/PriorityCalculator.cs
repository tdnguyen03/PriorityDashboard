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
                <= 1 => 50,
                <= 3 => 40,
                <= 7 => 30,
                <= 14 => 20,
                _ => 10
            };

            int effortScore = (int)task.Effort * 10;
            int importanceScore = (int)task.Importance * 10;

            int total = deadlineScore + effortScore + importanceScore;

            return Math.Min(total, 100);
        }
    }
}