using AutoMapper;
using FinalOfUber.DTOs.Vehicle;
using FinalOfUber.Models;

namespace FinalOfUber.Mappings.VehicleMppings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateAndUpdateVehicle, Vehicle>();
        }
    }
}
