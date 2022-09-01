using AutoMapper;
using MainProjectCORE.DTOs;
using MainProjectCORE.Model;
using MainProjectCORE.Repositories.Abstract;
using MainProjectCORE.Services;
using MainProjectCORE.UnitOfWorks;

namespace MainProjectService.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categortRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categortRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categortRepository = categortRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categortRepository.GetSingleCategoryGetByIdWithProductsAsync(categoryId);

            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
