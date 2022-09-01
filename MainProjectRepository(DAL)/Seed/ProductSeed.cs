﻿using MainProjectCORE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainProjectRepository_DAL_.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Name = "Kalem 1",
                CategoryId = 1,
                Price = 100,
                Stock = 20,
                CreateDate = DateTime.Now

            },
            new Product
            {
                Id = 2,
                Name = "Kalem 2",
                CategoryId = 1,
                Price = 300,
                Stock = 200,
                CreateDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                Name = "Kalem 3",
                CategoryId = 1,
                Price = 500,
                Stock = 50,
                CreateDate = DateTime.Now
            },
            new Product
            {
                Id = 4,
                Name = "Kitap 1",
                CategoryId = 2,
                Price = 5000,
                Stock = 50,
                CreateDate = DateTime.Now
            },
            new Product
            {
                Id = 5,
                Name = "Kitap 2",
                CategoryId = 2,
                Price = 3000,
                Stock = 100,
                CreateDate = DateTime.Now
            });
        }
    }
}
