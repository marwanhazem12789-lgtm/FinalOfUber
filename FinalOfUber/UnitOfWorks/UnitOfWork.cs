using FinalOfUber.AllCustoms.RatingCustom;
using FinalOfUber.AllCustoms.RideCustom;
using FinalOfUber.AllCustoms.UserCustom;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;

namespace FinalOfUber.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public IGenaricRepo<Vehicle> Vehicle { get; }

        public IUserRepo User { get; }

        public IGenaricRepo<Payment> Payment { get; }

        public IRatingRepo Rating { get; }

        public IRideRepo Ride { get; }
        public UnitOfWork(Context c , IGenaricRepo<Vehicle>v,IGenaricRepo<Payment> p , IRatingRepo r , IUserRepo u , IRideRepo rd)
        {
            _context = c;
            Vehicle = v;
            Payment = p;
            Ride = rd;
            Rating = r;
            User = u;
        }
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
