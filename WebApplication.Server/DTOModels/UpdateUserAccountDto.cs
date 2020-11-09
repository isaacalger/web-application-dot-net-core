using System.ComponentModel.DataAnnotations;

namespace WebApplication.Server.DTOModels
{
    public class UpdateUserAccountDto
    {

        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
