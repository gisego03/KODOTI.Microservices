using Catalog.Domain;
using Catalog.Persistence.Database.Configuraciones;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catalog.Persistence.Database
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInStock> Stocks{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new ProductInStockConfiguration(modelBuilder.Entity<ProductInStock>());
        }

    }
}
