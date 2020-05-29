using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistence.Database.Configuraciones
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entity)
        {
            entity.HasIndex(x => x.ProductInStockId);
            var stocks = new List<ProductInStock>();
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                var stock = new ProductInStock()
                {
                    ProductId = i,
                    ProductInStockId = i,
                    Stock = random.Next(0, 100)
                };
                stocks.Add(stock);
            }


            entity.HasData(stocks);
        }
    }
}
