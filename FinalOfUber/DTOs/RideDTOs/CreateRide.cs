using FinalOfUber.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.DTOs.RideDTOs
{
    public class CreateRide
    {
       
        public string PickupLocatin { get; set; }
        public string DropOffLocatin { get; set; }
        public int Fare { get; set; }
        public string Status { get; set; }
        public int DriverId { get; set; }
        public int RiderId { get; set; }
    }
}
