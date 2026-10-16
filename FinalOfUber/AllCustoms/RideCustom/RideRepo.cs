using FinalOfUber.DTOs.RideDTOs;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalOfUber.AllCustoms.RideCustom
{
    public class RideRepo : GenaricRepo<Ride> , IRideRepo
    {
        private readonly Context _context;
        public RideRepo(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GetAllRides>> Filter(string Status, int MinFare, int MaxFare, string SortBy)
        {
            var r = _context.rides.Include(i => i.Driver).AsQueryable();
            if (!string.IsNullOrEmpty(Status))
            {
                r = r.Where(i => i.Status.Contains(Status));
            }
            if(MinFare > 0)
            {
                r = r.Where(i => i.Fare >= MinFare);
            }
            if (MaxFare > 0)
            {
                r = r.Where(i => i.Fare <= MaxFare);
            }
            if (SortBy == "PickupLocatin" || SortBy == "pickupLocatin")
            {
                r = r.OrderBy(i => i.PickupLocatin);
            }
            if (SortBy == "DropOffLocatin" || SortBy == "dropOffLocatin")
            {
                r = r.OrderBy(i => i.DropOffLocatin);
            }
            if (SortBy == "Fare" || SortBy == "fare")
            {
                r = r.OrderBy(i => i.Fare);
            }
            if (SortBy == "Status" || SortBy == "status")
            {
                r = r.OrderBy(i => i.Status);
            }
            return await r
           
           .Select(i => new GetAllRides
           {
               Id = i.Id,
               Status = i.Status,
               DropOffLocatin = i.DropOffLocatin,
               PickupLocatin = i.PickupLocatin,
               Fare = i.Fare,
               DriverName = i.Driver.FullName
           }).ToListAsync();
        }

        public async Task<List<GetAllRides>> Paginaion(int PageIndex, int pageSize, string SortBy)
        {
         var r= _context.rides.Include(i => i.Driver).AsQueryable();
            if(SortBy == "PickupLocatin" || SortBy == "pickupLocatin")
            {
                r = r.OrderBy(i => i.PickupLocatin);
            }
            if (SortBy == "DropOffLocatin" || SortBy == "dropOffLocatin")
            {
                r = r.OrderBy(i => i.DropOffLocatin);
            }
            if (SortBy == "Fare" || SortBy == "fare")
            {
                r = r.OrderBy(i => i.Fare);
            }
            if (SortBy == "Status" || SortBy == "status")
            {
                r = r.OrderBy(i => i.Status);
            }
            return await r
            .Skip((PageIndex - 1) * pageSize)
            .Take(pageSize)
            .Select(i => new GetAllRides
            {
                Id = i.Id,
                Status = i.Status,
                DropOffLocatin = i.DropOffLocatin,
                PickupLocatin = i.PickupLocatin,
                Fare = i.Fare,
                DriverName = i.Driver.FullName
            }).ToListAsync();
        }

    
        public async Task<List<GetAllRides>> Search(string Pick)
        {
            return await _context.rides.Where(i => i.PickupLocatin.Contains(Pick)).Select(i => new GetAllRides
            {
                Id = i.Id,
                Status = i.Status,
                DropOffLocatin = i.DropOffLocatin,
                PickupLocatin = i.PickupLocatin,
                Fare = i.Fare,

            }).ToListAsync();
        }
    }
}
