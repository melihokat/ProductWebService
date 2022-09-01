using MainProjectCORE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainProjectRepository_DAL_.Seed
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Kalem" },
                new Category { Id = 2, Name = "Defter" },
                new Category { Id = 3, Name = "Kitap" });

        }
    }
}
