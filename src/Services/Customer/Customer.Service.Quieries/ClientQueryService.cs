using Customer.Persistence.Database;
using Customer.Service.Quieries.DTOs;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Quieries
{
    public interface IClientQueryService
    {
        Task<DataCollection<ClientDTO>> GetAllAsync(int page, int take, IEnumerable<int> clients = null);
        Task<ClientDTO> GetAsync(int id);
    }
    public class ClientQueryService : IClientQueryService
    {
        private readonly CustomerDbContext dbContext;
        private readonly ILogger<ClientQueryService> logger;

        public ClientQueryService(CustomerDbContext dbContext, ILogger<ClientQueryService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<DataCollection<ClientDTO>> GetAllAsync(int page, int take, IEnumerable<int> clients = null)
        {
            var collection = await dbContext.Clients
                .Where(x => clients == null || clients.Contains(x.ClientId))
                .OrderBy(x => x.ClientId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ClientDTO>>();
        }

        public async Task<ClientDTO> GetAsync(int id)
        {
            var data = await dbContext.Clients.FindAsync(id);
            return data.MapTo<ClientDTO>();
        }
    }
}
