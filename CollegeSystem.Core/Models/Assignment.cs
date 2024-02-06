using CollegeSystem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models
{
    public class Assignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FileURL Is Required")]
        public string FileURL { get; set; }

        [Required(ErrorMessage = "Grade Is Required")]
        [Range(0,50,ErrorMessage ="Assignment Grade is Invalid")]
        public decimal Grade { get; set; }

        [AssignmentDuration(ErrorMessage = "DeadLine must be 3 days later at minimum")]
        [Required(ErrorMessage = "DeadLine Is Required")]
        public DateTime DeadLine { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Guid TeacherId;
        public Teacher Teacher { get; set; }

        public ICollection<StudentAssignment> StudentAssignments { get; set; }

        public ICollection<AssignmentSolution> AssignmentSolution { get; set; }

    }
}
