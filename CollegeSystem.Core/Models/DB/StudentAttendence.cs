using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.DB
{
    public class StudentAttendence
    {
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
