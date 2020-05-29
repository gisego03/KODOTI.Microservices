using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Service.Common.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
    public class ClientCreateEventHandler : INotificationHandler<ClientCreateCommand>
    {
        private readonly CustomerDbContext dbContext;
        private readonly ILogger<ClientCreateEventHandler> logger;

        public ClientCreateEventHandler(CustomerDbContext dbContext, ILogger<ClientCreateEventHandler> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"---Stared ClientCreateEventHandler's handler");

            var client = notification.MapTo<Client>();

            await dbContext.AddAsync(client);
            await dbContext.SaveChangesAsync();
        }
    }
}
