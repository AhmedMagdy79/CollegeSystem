using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models
{
    public class Attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool IsPresent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DeliverDate { get; set; } = DateTime.UtcNow;

        public int CourseId;
        public Course Course { get; set;}

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
