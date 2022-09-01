using AutoMapper;
using MainProjectCORE.DTOs;
using MainProjectCORE.Model;
using MainProjectCORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainProjectAPI.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        //private readonly IService<Product> _service;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, /*IService<Product> service*/ IProductService service)
        {
            _mapper = mapper;
            _service = service;
            //_productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        { //Bu methoda girdikten sonra , sonuç dönmeden önce , döndükten sonra gibi aralarda business kodlar ekleyebiliyoruz.
            //filterlar bu işe yarar , middleware de bir üst seviyesidir.
            //bu durumlar validation için geçerlidir.


            return CreateActionResult(await _service.GetProductsWithCategory());
            //kodu tek satıra indirdik. Generic olmadığı için özelleştirilmiş bir service olduğu için
            //apinin istediği datayı service katmanında üretebiliriz.
        }




        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAysnc();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
            //Bu kod çirkin gözüküyor , bunun için Basecontroller oluşturur ve orada kullanırız.

            return CreateActionResult<List<ProductDto>>(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        //www.mysite.com/api/product/5  GET/api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]

        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]

        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        //DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}
