using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models
{
    public class StudentAssignment
    {
        public int AssignmentId { get; set; }
        public Assignment Assingment { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
