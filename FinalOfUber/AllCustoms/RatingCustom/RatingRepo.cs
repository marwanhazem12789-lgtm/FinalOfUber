using FinalOfUber.DTOs.RatingDTOs;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalOfUber.AllCustoms.RatingCustom
{
    public class RatingRepo : GenaricRepo<Rating> , IRatingRepo
    {
        private readonly Context _conext;
        public RatingRepo(Context conext) : base(conext) 
        {
            _conext = conext;
        }

        public async Task<List<GetAllRating>> Top()
        {
            return await _conext.ratings.OrderByDescending(i => i.Score).Take(3).Select(i => new GetAllRating
            {
                Id = i.Id,
                Score = i.Score,
                Comments = i.Comments,
            }).ToListAsync();
        }
    }
}
