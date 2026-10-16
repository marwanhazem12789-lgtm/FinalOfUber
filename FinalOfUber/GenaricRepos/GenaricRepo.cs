using FinalOfUber.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalOfUber.GenaricRepos
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly Context _contxet;
        public GenaricRepo(Context contxet)
        {
            _contxet = contxet;
        }


        public async Task Add(T item)
        {
            await _contxet.Set<T>().AddAsync(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _contxet.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _contxet
                .Set<T>().FindAsync(id);
        }

        public void Remove(T item)
        {
            _contxet.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            _contxet.Set<T>().Update(item);
        }
    }
}
