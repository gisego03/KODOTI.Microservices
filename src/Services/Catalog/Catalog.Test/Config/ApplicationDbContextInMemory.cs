using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Test.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static CatalogDbContext Get()
        {
            var options = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                .Options;
            return new CatalogDbContext(options);
        }
    }
}
