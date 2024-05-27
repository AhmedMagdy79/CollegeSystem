using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Core.Attributes
{
    public class AssignmentDuration : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var deadLine = (DateTime)value;
            var currentDate = DateTime.UtcNow;

            if (deadLine <= currentDate || deadLine < currentDate.AddDays(3))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
