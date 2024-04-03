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
        public DbSet<StudentAttendence> StudentAttendences { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AssignmentSolution>().HasKey(a => new { a.StudentId, a.AssignmentId });
            modelBuilder.Entity<StudentAssignment>().HasKey(s => new { s.StudentId, s.AssignmentId });
            modelBuilder.Entity<StudentCourses>().HasKey(s => new { s.StudentId, s.CourseId });
            modelBuilder.Entity<StudentAttendence>().HasKey(s => new { s.StudentId, s.CourseId });
            modelBuilder.Entity<Admin>().HasKey(a => a.UserId);
            modelBuilder.Entity<Teacher>().HasKey(a => a.UserId);
            modelBuilder.Entity<Student>().HasKey(a => a.UserId);

            modelBuilder.Entity<User>()
                    .HasOne(u => u.Student)
                    .WithOne(s => s.User)
                    .HasForeignKey<Student>(a => a.UserId);

            modelBuilder.Entity<User>()
                    .HasOne(u => u.Teacher)
                    .WithOne(t => t.User)
                    .HasForeignKey<Teacher>(a => a.UserId);


            modelBuilder.Entity<User>()
                    .HasOne(u => u.Admin)
                    .WithOne(a => a.User)
                    .HasForeignKey<Admin>(a => a.UserId);

            //on delete actions for users 

            //teacher
            modelBuilder.Entity<Teacher>()
                        .HasMany(t => t.Assignment)
                        .WithOne(a => a.Teacher)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                        .HasMany(t => t.course)
                        .WithOne(a => a.Teacher)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                        .HasMany(t => t.Exam)
                        .WithOne(a => a.Teacher)
                        .OnDelete(DeleteBehavior.Restrict);

            //student
        }

    }
}
