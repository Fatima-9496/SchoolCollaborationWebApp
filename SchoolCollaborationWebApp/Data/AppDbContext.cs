using Microsoft.EntityFrameworkCore;
using SchoolCollaborationWebApp.Models;

namespace SchoolCollaborationWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestSubmission> TestSubmissions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
