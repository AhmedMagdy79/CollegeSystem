using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.DB
{
    public class Student
    {
        public User User;
        public string UserId { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }

        public ICollection<StudentAssignment> StudentAssignments { get; set; }

        public ICollection<AssignmentSolution> AssignmentSolution { get; set; }

        public ICollection<StudentAttendence> StudentAttendences { get; set; }

    }
}
