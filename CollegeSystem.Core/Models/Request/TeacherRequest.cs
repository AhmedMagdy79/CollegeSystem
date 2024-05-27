using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Core.Models.Request
{
    public class TeacherRequest : UserRequest
    {
        [Range(1, double.MaxValue, ErrorMessage = "Salary Value Invalid")]
        public decimal Salary { get; set; }
    }
}
