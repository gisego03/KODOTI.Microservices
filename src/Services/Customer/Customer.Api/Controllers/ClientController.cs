using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Service.EventHandlers.Commands;
using Customer.Service.Quieries;
using Customer.Service.Quieries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientQueryService clientQueryService;
        private readonly IMediator mediator;

        public ClientController(ILogger<ClientController> logger, IClientQueryService clientQueryService, IMediator mediator)
        {
            _logger = logger;
            this.clientQueryService = clientQueryService;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ClientDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> clients = null;
            if (!string.IsNullOrEmpty(ids))
                clients = ids.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x));

            return await clientQueryService.GetAllAsync(page, take, clients);
        }

        [HttpGet("{id}")]
        public async Task<ClientDTO> Get(int id)
        {
            return await clientQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateCommand command)
        {
            try
            {
                await mediator.Publish(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
