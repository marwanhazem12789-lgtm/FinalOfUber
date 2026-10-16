using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.Models
{
    public class Vehicle
    {
        [Key]
        public int Id {  get; set; }
        public string PalteNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public  User Driver { get; set; }
        [ForeignKey(nameof(User))]
        public int DriverId { get; set; }
    }
}
