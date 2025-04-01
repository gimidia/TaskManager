using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities; 

namespace TaskManager.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        public DbSet<TaskItem> TaskItems { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
