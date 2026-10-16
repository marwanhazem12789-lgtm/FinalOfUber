using AutoMapper;
using FinalOfUber.DTOs.UserDTOs;
using FinalOfUber.Models;

namespace FinalOfUber.Mappings.UserMappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetAllUsers>();
            CreateMap<RegisterDTOs, User>();
        }
    }
}
