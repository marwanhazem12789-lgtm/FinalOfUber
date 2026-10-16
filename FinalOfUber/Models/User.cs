using System.ComponentModel.DataAnnotations;

namespace FinalOfUber.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required ,MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required , Phone]

        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }

        public  Vehicle Vehicle { get; set; }


        public ICollection<Ride> Driverrides { get; set; } = new List<Ride>();
        public ICollection<Ride> Riderrides { get; set; } = new List<Ride>();
    }
}
