using System.Linq.Expressions;

namespace MainProjectCORE.Services
{
    public interface IService<T> where T : class //Repodan farkı dönüş tipleri farklıdır.
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAysnc();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        /*void*/
        Task UpdateAsync(T entity); //Savechange olacağı için aysnc yapılacak.
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
