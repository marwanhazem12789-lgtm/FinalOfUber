using FinalOfUber.DTOs.RatingDTOs;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;

namespace FinalOfUber.AllCustoms.RatingCustom
{
    public interface IRatingRepo : IGenaricRepo<Rating>
    {
        Task<List<GetAllRating>> Top();
    }
}
