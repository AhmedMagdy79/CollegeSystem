using CollegeSystem.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Core.Attributes
{
    public class ExamDuration : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime)value;
            var startDate = ((Exam)validationContext.ObjectInstance).StartTime;

            if (endDate <= startDate || endDate > startDate.AddHours(3))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
