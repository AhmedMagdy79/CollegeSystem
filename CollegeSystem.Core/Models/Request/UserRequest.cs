using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Core.Models.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }

    }
}
