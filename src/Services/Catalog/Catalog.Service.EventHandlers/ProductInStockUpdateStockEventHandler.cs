using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly CatalogDbContext dbContext;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> logger;
        public ProductInStockUpdateStockEventHandler(CatalogDbContext dbContext, ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {

            logger.LogInformation("---ProductInStockUpdateStockCommand stared");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await dbContext.Stocks.Where(x => products.Contains(x.ProductInStockId)).ToListAsync();
            logger.LogInformation("---Retrieved products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductInStockId == item.ProductId);
                switch (item.Action)
                {
                    case Common.Enums.ProductInStockAction.Add:
                        if(entry == null)
                        {
                            entry = new ProductInStock()
                            {
                                ProductId = item.ProductId
                            };
                            await dbContext.AddAsync(entry);

                            logger.LogInformation($"--- New stock record was created for {entry.ProductId} because didn't exists before");
                        }
                        entry.Stock += item.Stock;
                        logger.LogInformation($"---Product {entry.ProductId} - its stock was increased and its new stock is {entry.Stock}");


                        break;
                    case Common.Enums.ProductInStockAction.Substract:
                        
                        if (entry == null || item.Stock > entry.Stock)
                        {
                            logger.LogError($"---Product {entry.ProductId} - doesn't have enough stock");
                            throw new Exception($"Product {entry.ProductId} - doesn't have enough stock");
                        }
                        logger.LogInformation($"---Product {entry.ProductId} - its stock was subtracted and its new stock is {entry.Stock}");
                        entry.Stock -= item.Stock;
                        break;
                }

                await dbContext.SaveChangesAsync();

                logger.LogInformation("---ProductInStockUpdateStockCommand ended");

            }
        }
    }
}
