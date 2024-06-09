using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface ICourseService
    {
        Task<Course> AddCourseAsync(CourseRequest request);

        Task<bool> RemoveCourseAsync(int id);

        Task<bool> AssignCourseToTeacherAsync(string teacherId, int courseId);

        Task<List<Course>> GetStudentCoursesAsync(string studentId);

        Task<List<Course>> GetTeacherCoursesAsync(string teacherId);

        Task<Course> GetCourseClassWorkAsync(string courseId);
    }
}
