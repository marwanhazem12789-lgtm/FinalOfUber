using FinalOfUber.DTOs.RideDTOs;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;

namespace FinalOfUber.AllCustoms.RideCustom
{
    public interface IRideRepo : IGenaricRepo<Ride>
    {
        Task<List<GetAllRides>> Search(string Pick);
        Task<List<GetAllRides>> Paginaion(int PageIndex , int pageSize , string SortBy);
        Task<List<GetAllRides>> Filter(string Status, int MinFare ,int MaxFare ,  string SortBy);
    }
}
