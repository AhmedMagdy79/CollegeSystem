using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
