using CollegeSystem.Core.Models.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<AssignmentSolution> AssignmentSolutions { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity => { entity.ToTable("Users"); });
            modelBuilder.Entity<Teacher>(entity => { entity.ToTable("Teachers"); });
            modelBuilder.Entity<Student>(entity => { entity.ToTable("Students"); });
            modelBuilder.Entity<Admin>(entity => { entity.ToTable("Admins"); });
            modelBuilder.Entity<AssignmentSolution>().HasKey(a => new { a.StudentId, a.AssignmentId });
            modelBuilder.Entity<StudentAssignment>().HasKey(s => new { s.StudentId, s.AssignmentId });
            modelBuilder.Entity<StudentCourses>().HasKey(s => new { s.StudentId, s.CourseId });
        }

    }
}
