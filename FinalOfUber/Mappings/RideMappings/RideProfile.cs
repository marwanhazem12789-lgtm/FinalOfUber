using AutoMapper;
using FinalOfUber.DTOs.RideDTOs;
using FinalOfUber.Models;

namespace FinalOfUber.Mappings.RideMappings
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<CreateRide, Ride>();
            CreateMap<Ride, GetAllRides>();
        }
    }
}
