using System.ComponentModel.DataAnnotations;

namespace FinalOfUber.DTOs.UserDTOs
{
    public class LoginDTOs
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
