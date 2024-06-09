using CollegeSystem.Core.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.Request
{
    public class CourseRequest
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Range(1, 4, ErrorMessage = "Invalid Level Input")]
        public byte level { get; set; }

        public string TeacherId;
    }
}
