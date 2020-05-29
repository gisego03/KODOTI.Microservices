using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{

    public interface IProductInStockQueryService
    {
        Task<DataCollection<ProductInStockDTO>> GetAllAsync(int page, int take, IEnumerable<int> stocks = null);
        Task<ProductInStockDTO> GetAsync(int id);
    }

    public class ProductInStockQueryService : IProductInStockQueryService
    {
        private readonly CatalogDbContext dbContext;
        private readonly ILogger<ProductInStockQueryService> logger;
        public ProductInStockQueryService(CatalogDbContext dbContext, ILogger<ProductInStockQueryService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<DataCollection<ProductInStockDTO>> GetAllAsync(int page, int take, IEnumerable<int> stocks = null)
        {
            var collection = await dbContext.Stocks
                .Where(x => stocks == null || stocks.Contains(x.ProductId))
                .OrderBy(x => x.ProductInStockId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductInStockDTO>>();
        }

        public async Task<ProductInStockDTO> GetAsync(int id)
        {
            var data = await dbContext.Stocks.FindAsync(id);

            return data.MapTo<ProductInStockDTO>();
        }

    }
}
