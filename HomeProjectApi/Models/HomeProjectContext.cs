using Microsoft.EntityFrameworkCore;

namespace HomeProjectApi.Models
{
    public class HomeProjectContext : DbContext
    {
        public HomeProjectContext(DbContextOptions<HomeProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectItem> ProjectItems { get; set; }
    }
}