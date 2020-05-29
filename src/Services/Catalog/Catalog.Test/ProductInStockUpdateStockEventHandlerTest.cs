using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Test.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enums;

namespace Catalog.Test
{
    [TestClass]
    public class ProductInStockUpdateStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> logger
            => new Mock<ILogger<ProductInStockUpdateStockEventHandler>>()
                .Object;

        [TestMethod]
        public async Task TryToSubstractStockWhenProductHasStock()
        {
            var dbContext = ApplicationDbContextInMemory.Get();
            var productInStockId = 1;
            var productId = 1;

            dbContext.Stocks.Add(new ProductInStock
            {
                ProductId = productId,
                ProductInStockId = productInStockId,
                Stock = 1
            });

            dbContext.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(dbContext, logger);
            await handler.Handle(new ProductInStockUpdateStockCommand()
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem()
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract
                    }
                }
            }, CancellationToken.None);
                
            var p = dbContext.Stocks.Find(productId);
            Assert.Equals(p.Stock, 0);
        }
    }
}
