using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDTO> GetAsync(int id);

    }
    public class ProductQueryService : IProductQueryService
    {
        private readonly CatalogDbContext dbContext;

        public ProductQueryService(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await dbContext.Products
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderBy(x => x.ProductId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDTO>>();

        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var data = await dbContext.Products.FindAsync(id);//.SingleOrDefaultAsync(x=> )

            return data.MapTo<ProductDTO>();

        }

    }
}
