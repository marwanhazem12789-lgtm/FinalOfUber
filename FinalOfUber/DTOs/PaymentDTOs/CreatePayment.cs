using System.ComponentModel.DataAnnotations;

namespace FinalOfUber.DTOs.PaymentDTOs
{
    public class CreatePayment
    {
        [Required, Range(20, 5000)]
        public double Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]

        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }
        public int RideId { get; set; }
    }
}
