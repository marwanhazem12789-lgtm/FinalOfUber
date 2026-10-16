using System.ComponentModel.DataAnnotations;

namespace FinalOfUber.DTOs.UserDTOs
{
    public class GetAllUsers
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, Phone]

        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
