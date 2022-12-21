using lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace lab5.DB
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<EmployeeProject> EmployeeProjects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<EmployeeProject>().ToTable("EmployeeProject");
        }
    }
}
