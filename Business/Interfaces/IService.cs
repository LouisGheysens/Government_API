namespace Business.Interfaces
{
    //Generic interface
    public interface IService<T, U> where T : class where U : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(U id);
        Task<U> AddAsync(T item);
        Task<U> UpdateAsync(U id, T data);
        Task<U> DeleteAsync(U id);
    }
}
