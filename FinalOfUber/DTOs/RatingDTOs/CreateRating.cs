using FinalOfUber.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.DTOs.RatingDTOs
{
    public class CreateRating
    {
        public int Score { get; set; }
        public string Comments { get; set; }
        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
    }
}
