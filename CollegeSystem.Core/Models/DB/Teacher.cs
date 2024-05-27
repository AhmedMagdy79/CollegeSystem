namespace CollegeSystem.Core.Models.DB
{
    public class Teacher
    {
        public User User;
        public string UserId { get; set; }

        public decimal Salary { get; set; }

        public ICollection<Course> course;

        public ICollection<Exam> Exam;

        public ICollection<Assignment> Assignment;
    }
}
