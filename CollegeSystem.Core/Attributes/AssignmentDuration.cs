using CollegeSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
