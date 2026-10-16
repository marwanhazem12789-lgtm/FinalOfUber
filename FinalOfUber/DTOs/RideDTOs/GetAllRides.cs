using System.ComponentModel.DataAnnotations;

namespace FinalOfUber.DTOs.RideDTOs
{
    public class GetAllRides
    {
        [Key]
        public int Id { get; set; }
        public string PickupLocatin { get; set; }
        public string DropOffLocatin { get; set; }
        public int Fare { get; set; }
        public string Status { get; set; }
        public string DriverName { get; set; }
    }
}
