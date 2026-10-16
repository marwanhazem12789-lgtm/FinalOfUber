namespace FinalOfUber.GenaricRepos
{
    public interface IGenaricRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task  Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
