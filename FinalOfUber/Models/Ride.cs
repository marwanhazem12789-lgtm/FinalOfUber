using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        public string PickupLocatin {  get; set; }
        public string DropOffLocatin {  get; set; }
        public int Fare {  get; set; }
        public  string Status { get; set; }
        public User Driver { get; set; }
        [ForeignKey(nameof(User))]
        public int DriverId { get; set; }



        public User Rider { get; set; }
        [ForeignKey(nameof(User))]
        public int RiderId { get; set; }

        public Payment Payment {  get; set; }
        public Rating   Rating {  get; set; }
    }
}
