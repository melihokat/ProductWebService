using AutoMapper;
using MainProject.WEBMVC.SERVICES;
using MainProjectCORE.DTOs;
using MainProjectCORE.Model;
using MainProjectCORE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MainProject.WEBMVC.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly IProductService _services;
        //private readonly ICategoryService _categoryService;
        //private readonly IMapper _mapper;

        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(/*IProductService services, ICategoryService categoryService, IMapper mapper,*/ CategoryApiService categoryApiService, ProductApiService productApiService)
        {
            //_services = services;
            //_categoryService = categoryService;
            //_mapper = mapper;
            _categoryApiService = categoryApiService;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            //var customResponse = await _services.GetProductsWithCategory();
            //return View(customResponse.Data);
            
            return View(await _productApiService.GetProductsWithCategoryAsync());

            //direkt productsu dönebilirdik burada , customresponse dönemmize gerek yok hata kodu olmadığı için.
        }

        public async Task<IActionResult> Save()
        {
            //var categories = await _categoryService.GetAllAysnc();
            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            //ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            //return View();
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Save(ProductDto productDto)
        {
            //burayı tekrar aldık , name alanı eksik butona basılırsa bu save alanında tekrardan bunları doldurmak gerekir.
            //başarılı devam ederse Indexe yönlenecek tekrardan.



            //Hata var ise bu sayfa tekrardan çalışır

            //if (ModelState.IsValid)
            //{
            //    await _services.AddAsync(_mapper.Map<Product>(productDto));
            //    return RedirectToAction(nameof(Index));
            //}
            //var categories = await _categoryService.GetAllAysnc();
            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            //ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            //return View();


            if (ModelState.IsValid)
            {
                await _productApiService.SaveAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            var categoriesDto= await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();

        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            //var product = await _services.GetByIdAsync(id);

            //var categories = await _categoryService.GetAllAysnc();

            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            //ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);

            //return View(_mapper.Map<ProductDto>(product));

            var product = await _productApiService.GetByIdAsync(id);
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ProductDto productDto)
        {
            //if (ModelState.IsValid)
            //{
            //    await _services.UpdateAsync(_mapper.Map<Product>(productDto));
            //    return RedirectToAction(nameof(Index));
            //}

            //var categories = await _categoryService.GetAllAysnc();

            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            //ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);

            //return View(productDto);

            if (ModelState.IsValid)
            {
                await _productApiService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);
            return View(productDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            //var product = await _services.GetByIdAsync(id);

            //await _services.RemoveAsync(product);
            //return RedirectToAction(nameof(Index));

            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
