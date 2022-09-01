using MainProjectCORE.Model;
using MainProjectCORE.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MainProjectRepository_DAL_.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> GetSingleCategoryGetByIdWithProductsAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        } //SingleOrDefault da id'den birden fazla varsa hata döner.
    }
}
