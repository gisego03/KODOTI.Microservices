using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class ProductCreateEventHandler : 
        INotificationHandler<ProductCreateCommand>
    {
        private readonly CatalogDbContext dbContext;

        public ProductCreateEventHandler(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            var product = command.MapTo<Product>();
            await dbContext.AddAsync(product);
        }
    }
}
