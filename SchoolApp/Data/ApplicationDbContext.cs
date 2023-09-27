 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnounceAndProjView> AnnounceAndProjViews { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<MNote> MNotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>()
                .HasMany(a => a.AssignmentSubmissions)
                .WithOne(s => s.Assignment)
                .OnDelete(DeleteBehavior.Cascade);
                        
            modelBuilder.Entity<Course>()
                .HasMany(a => a.Assignments)
                .WithOne(s => s.Course)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany(a => a.Enrollments)
                .WithOne(s => s.Course)
                .OnDelete(DeleteBehavior.Cascade);
        }       

    }
}