using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using MainProjectAPI.Filters;
using MainProjectAPI.Middlewares;
using MainProjectAPI.Modules;
using MainProjectRepository_DAL_;
using MainProjectService.Mapping;
using MainProjectService.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidation>());
//Fluent validation kendi responsesini d�nmeden �nce bizim filterimiz kendi responsesesini d�necek.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; //buras� api taraf�nda default olarak aktiftir.
});
//Apinin default d�nd��� modeli kapatmam�z laz�m , bizim kendi filterimiz var demeliyiz.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile)); // Tipini verdik hangi assembly de oldu�unu anlar.

//builder.Services.AddScoped<IProductRepository,ProductRepository>();  
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();  Buralar� Autofac ile otomatikle�tirdik.
//builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});




builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(countainerBuilder => countainerBuilder.RegisterModule(new RepoServiceModule()));

//birden fazla modul olursa buralara ekliyoruz.





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UserCustomException(); //Kendi yazd���m�z hatay� ekleriz.Middleware ba�larda olmal�d�r.

app.UseAuthorization();

app.MapControllers();

app.Run();
