using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.Request
{
    public class TeacherRequest : UserRequest
    {
        [Range(1,double.MaxValue, ErrorMessage = "Salary Value Invalid")]
        public decimal Salary { get; set; }
    }
}
