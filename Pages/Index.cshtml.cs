using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityDashboard.Data;
using PriorityDashboard.Models;
using PriorityDashboard.Services;

namespace PriorityDashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<TaskItem> Tasks { get; set; }

        [BindProperty]
        public TaskItem NewTask { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Tasks = _context.Tasks
                .OrderByDescending(t => t.Score)
                .ToList();
        }

        public IActionResult OnPost()
        {
            // Convert subtasks input into storage format
            if (!string.IsNullOrEmpty(NewTask.SubtasksRaw))
            {
                var parts = NewTask.SubtasksRaw
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim());

                NewTask.SubtasksRaw = string.Join("|", parts);
            }

            NewTask.Score = PriorityCalculator.Calculate(NewTask);
            _context.Tasks.Add(NewTask);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostAddSubtask(int id, string subtask)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null && !string.IsNullOrWhiteSpace(subtask))
            {
                var existing = (task.SubtasksRaw ?? "").Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
                existing.Add(subtask.Trim());
                task.SubtasksRaw = string.Join("|", existing);

                _context.SaveChanges();
            }

            return RedirectToPage();
        }

    }
}
