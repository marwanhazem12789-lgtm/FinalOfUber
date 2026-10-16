using AutoMapper;
using FinalOfUber.DTOs.RatingDTOs;
using FinalOfUber.Models;

namespace FinalOfUber.Mappings.RatingMappings
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<CreateRating, Rating>();
        }
    }
}
