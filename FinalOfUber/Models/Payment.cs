using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required , Range(20 , 5000)]
        public double Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]

        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }

        public Ride Ride {  get; set; }
        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
    }
}
