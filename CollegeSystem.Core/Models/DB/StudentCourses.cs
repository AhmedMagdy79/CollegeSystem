namespace CollegeSystem.Core.Models.DB
{
    public class StudentCourses
    {
        public int CourseId;
        public Course Course { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
