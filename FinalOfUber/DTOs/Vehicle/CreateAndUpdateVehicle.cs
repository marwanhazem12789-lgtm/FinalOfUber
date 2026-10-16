using FinalOfUber.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOfUber.DTOs.Vehicle
{
    public class CreateAndUpdateVehicle
    {
        public string PalteNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int DriverId { get; set; }
    }
}
