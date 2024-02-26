using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.DB
{
    public class Teacher : User
    {
        [Range(0, double.MaxValue, ErrorMessage = "Salary Value is Not Valid")]
        public decimal Salary { get; set; }

        public ICollection<Course> course;

        public ICollection<Exam> Exam;

        public ICollection<Assignment> Assignment;
    }
}
