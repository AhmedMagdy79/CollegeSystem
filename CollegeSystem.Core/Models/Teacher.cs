using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models
{
    public class Teacher : User
    {
        [Range(0,Double.MaxValue, ErrorMessage ="Salary Value is Not Valid")]
        public decimal Salary;


    }
}
