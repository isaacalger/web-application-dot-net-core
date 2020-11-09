using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Server.DTOModels
{
    public class RegisterUserAccountDto : IValidatableObject
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Confirmation Does not match Password.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (!Password.Equals(ConfirmPassword))
            {
                results.Add(new ValidationResult("The Password Confirmation must match the Password", new []{"Password", "Password Confirmation"}));
            }

            return results;
        }
    }
}
