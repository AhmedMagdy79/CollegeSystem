using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.Core.Models.DB
{
    public class Attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public int CourseId { get; set; }
        public Course course { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        [DefaultValue(false)]
        public bool IsPresent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ClassDate { get; set; } = DateTime.UtcNow;
    }
}
