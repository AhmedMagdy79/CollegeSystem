using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;

namespace CollegeSystem.API.Services
{
    public class CourseService : ICourseService
    {
        public Task<Course> AddCourseAsync(CourseRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignCourseToTeacherAsync(string teacherId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseClassWorkAsync(string courseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetStudentCoursesAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetTeacherCoursesAsync(string teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCourseAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
