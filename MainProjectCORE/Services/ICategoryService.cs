using MainProjectCORE.DTOs;
using MainProjectCORE.Model;

namespace MainProjectCORE.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
