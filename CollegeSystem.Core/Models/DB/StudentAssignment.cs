namespace CollegeSystem.Core.Models.DB
{
    public class StudentAssignment
    {
        public int AssignmentId { get; set; }
        public Assignment Assingment { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
