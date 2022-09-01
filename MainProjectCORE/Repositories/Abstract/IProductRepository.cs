using MainProjectCORE.Model;

namespace MainProjectCORE.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCagetory();
    }
}
