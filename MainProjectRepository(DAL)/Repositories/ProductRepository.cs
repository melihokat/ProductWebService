using MainProjectCORE.Model;
using MainProjectCORE.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MainProjectRepository_DAL_.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    { //Hem Generic , Hem de IProductRepository'e erişebiliriz. Genericleri tekrardan miras almaz.
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCagetory()
        {
            return await _appDbContext.Products.Include(x => x.Category).ToListAsync();
            //Eager loading , datalar çekilirken bağlı olduğu kategori de alınsın istedik, daha sonra çekilirse lazyloading.

        }
    }
}
