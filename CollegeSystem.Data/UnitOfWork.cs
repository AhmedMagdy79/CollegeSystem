using CollegeSystem.Core;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Repositories;
using CollegeSystem.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace CollegeSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Assignment> Assignments  {get; private set;}

        public IBaseRepository<AssignmentSolution> AssignmentSolutions  {get; private set;}

        public IBaseRepository<Attendance> Attendances  {get; private set;}

        public IBaseRepository<Course> Courses  {get; private set;}

        public IBaseRepository<Event> Events  {get; private set;}

        public IBaseRepository<Exam> Exams  {get; private set;}

        public IBaseRepository<StudentAssignment> StudentAssignments  {get; private set;}

        public IBaseRepository<StudentCourses> StudentCoursess  {get; private set;}

        public IBaseRepository<StudentAttendence> StudentAttendences { get; private set; }

        public ITokenRepository Tokens { get; private set; } 
        public IBaseRepository<Admin> Admin { get; private set; }

        public IBaseRepository<Teacher> Teacher { get; private set; }

        public IBaseRepository<Student> Student { get; private set; }

        public IBaseRepository<User> User { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Assignments = new BaseRepository<Assignment>(_context);
            AssignmentSolutions = new BaseRepository<AssignmentSolution>(_context);
            Attendances = new BaseRepository<Attendance>(_context);
            Courses = new BaseRepository<Course>(_context);
            Events = new BaseRepository<Event>(_context);
            Exams = new BaseRepository<Exam>(_context);
            StudentAssignments = new BaseRepository<StudentAssignment>(_context);
            StudentCoursess = new BaseRepository<StudentCourses>(_context);
            StudentAttendences = new BaseRepository<StudentAttendence>(_context);
            Admin = new BaseRepository<Admin>(_context);
            Teacher = new BaseRepository<Teacher>(_context);
            Student = new BaseRepository<Student>(_context);
            User = new BaseRepository<User>(_context);
            Tokens = new TokenRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
