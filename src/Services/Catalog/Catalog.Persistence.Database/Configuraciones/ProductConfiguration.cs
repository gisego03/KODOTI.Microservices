using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistence.Database.Configuraciones
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entity)
        {
            entity.HasIndex(x => x.ProductId);
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Description).IsRequired().HasMaxLength(500);

            var products = new List<Product>();
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                var product = new Product()
                {
                    ProductId = i,
                    Name = $"Product {i}",
                    Description = $"Description for product {i}",
                    Price = random.Next(100, 1000),
                    //Stock = new ProductInStock()
                    //{
                    //    ProductId = i,
                    //    ProductInStockId = i,
                    //    Stock = random.Next(0,100)
                    //}
                };
                products.Add(product);
            }


            entity.HasData(products);
        }
    }
}
