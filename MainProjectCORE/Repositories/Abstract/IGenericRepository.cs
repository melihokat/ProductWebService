using System.Linq.Expressions;

namespace MainProjectCORE.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        //productRepository.where(x=>x.id<5) buraya kadar iqueryable , veritabanına sorgu yapmadık. .ToListAsync() dersek bu zaman veritabanına sorgu yapar.
        IQueryable<T> Where(Expression<Func<T, bool>> expression); //Direkt veritabanına gitmez. To list gibi methodlarla veritabanına gider.
        //bool tipinde true ya da false gelip kayıtlar dönecek.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
