using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductInStockController : ControllerBase
    {
        private readonly ILogger<ProductInStockController> _logger;
        private readonly IProductInStockQueryService productInStockQueryService;
        private readonly IMediator mediator;

        public ProductInStockController(
            ILogger<ProductInStockController> logger,
            IProductInStockQueryService productInStockQueryService, 
            IMediator mediator)
        {
            _logger = logger;
            this.productInStockQueryService = productInStockQueryService;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ProductInStockDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> products = null;
            if (!string.IsNullOrEmpty(ids))
                products = ids.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x));

            return await productInStockQueryService.GetAllAsync(page, take, products);
        }

        [HttpGet("{id}")]
        public async Task<ProductInStockDTO> Get(int id)
        {
            return await productInStockQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            await mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command)
        {
            await mediator.Publish(command);
            return Ok();
        }


    }
}
