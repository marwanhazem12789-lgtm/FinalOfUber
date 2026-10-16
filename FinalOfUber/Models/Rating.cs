using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
        public Ride Ride {  get; set; }
    }
}
