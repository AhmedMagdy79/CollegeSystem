using CollegeSystem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.DB
{
    public class Exam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "StartTime Is Required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime Is Required")]
        [ExamDuration(ErrorMessage = "Duration Time Should Be 3 hours Maximum")]
        public DateTime EndTime { get; set; }

        [DefaultValue(false)]
        public bool IsCanceled { get; set; }

        public string TeacherId;
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
