﻿namespace MainProjectCORE.Model
{
    public class Product : BaseEntity
    {
        //public Product(string name)
        //{
        //    Name=name ?? throw new ArgumentNullException(nameof(Name));
        //} //Yeşil tırtıklar Nullable için gözüküyor. Yanlarına ? atılarak null olabilir denebilir.
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }

    }
}
