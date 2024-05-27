using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.Core.Models.DB
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Range(1, 4, ErrorMessage = "Invalid Level Input")]
        public byte level { get; set; }

        public string TeacherId;
        public Teacher Teacher { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public ICollection<StudentAttendence> StudentAttendences { get; set; }

    }
}
