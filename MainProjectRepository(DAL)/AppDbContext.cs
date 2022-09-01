using MainProjectCORE.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MainProjectRepository_DAL_
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //Startup bölümünden vereceğiz
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) //Ayarları yapmak için. Mesela name 50 karakter olacak.
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Git tüm assembly configuration dosyalarını oku(IEntityTypeConfiguration). Class library =  assembly
            //GetExecute çalışmış olduklarımızı bul ve uygula.
            //Mesela primary key vermemiz gerekirse buradan vermeliyiz kodu temiz tutmak için.
            //modelBuilder.Entity<Category>().HasKey(x=>x.Id) Bu sefer de burası kalabalık olacak. Ayrı bir class yapılır.

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {//Buradan da yapabilirz Ama bestpractice açısından iyi değildir.
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1,

            }, new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 300,
                Width = 500,
                ProductId = 2,


            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
