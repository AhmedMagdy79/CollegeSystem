namespace CollegeSystem.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(string id);

        T Delete(T entity);

        T Update(T entity);
    }
}
