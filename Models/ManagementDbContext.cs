using Microsoft.EntityFrameworkCore;

namespace ExamTP.Models
{
    public class ManagementDbContext:DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
        { }

        public DbSet<Management> Managements { get; set; }
    }
}
