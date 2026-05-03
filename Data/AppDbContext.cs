using Microsoft.EntityFrameworkCore;
using PriorityDashboard.Models;

namespace PriorityDashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}