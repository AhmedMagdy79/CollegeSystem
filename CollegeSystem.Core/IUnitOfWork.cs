using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBaseRepository<Assignment> Assignments { get; }
        IBaseRepository<AssignmentSolution> AssignmentSolutions { get; }
        IBaseRepository<Attendance> Attendances { get; }
        IBaseRepository<Course> Courses { get; }
        IBaseRepository<Event> Events { get; }
        IBaseRepository<Exam> Exams { get; }
        IBaseRepository<StudentAssignment> StudentAssignments { get; }
        IBaseRepository<StudentCourses> StudentCoursess { get; }
        IBaseRepository<StudentAttendence> StudentAttendences { get; }
        IBaseRepository<Admin> Admin { get; }
        IBaseRepository<Teacher> Teacher { get; }
        IBaseRepository<Student> Student { get; }
        IBaseRepository<User> User { get; }
        ITokenRepository Tokens { get; }


        Task SaveAsync();
    }
}
