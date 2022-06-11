namespace Business.Interfaces
{
    //Generic interface
    public interface IService<T, U> where T : class where U : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(U id);
        Task AddAsync(T item);
        Task UpdateAsync(U id, T data);
        Task DeleteAsync(U id);
    }
}
