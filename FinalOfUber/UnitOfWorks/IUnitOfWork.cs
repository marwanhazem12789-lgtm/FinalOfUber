using FinalOfUber.AllCustoms.RatingCustom;
using FinalOfUber.AllCustoms.RideCustom;
using FinalOfUber.AllCustoms.UserCustom;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;

namespace FinalOfUber.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenaricRepo<Vehicle> Vehicle { get; }  
        IUserRepo User { get; }  
        IGenaricRepo<Payment> Payment { get; }  
        IRatingRepo Rating { get; }  
        IRideRepo Ride { get; }

        public Task<int> Save();
    }

}
