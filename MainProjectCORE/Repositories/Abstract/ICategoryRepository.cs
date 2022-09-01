using MainProjectCORE.Model;

namespace MainProjectCORE.Repositories.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryGetByIdWithProductsAsync(int categoryId);
    }
}
