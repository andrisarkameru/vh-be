using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VH.Core.Transport;
using VH.Currency;
using VH.Services.Interfaces;

namespace VH.DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IConfiguration _config;
        private readonly ICurrencyService _currencyService;
        private readonly IOrderService _orderService;


        public OrderController(
            ILogger<OrderController> logger,
            IConfiguration config,
            ICurrencyService currencyService,
            IOrderService orderService)
        {
            _logger = logger;
            _config = config;
            _currencyService = currencyService;
            _orderService = orderService;

        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            return await _orderService.ListOrders();
        }

        //Get 
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get(int id)
        {
            return await _orderService.ListOrders();
        }

        //Book an order

        [HttpPost]
        public async Task<OrderDTO> CreateOrder([FromBody] OrderDTO order)
        {
            var orderCreation = await _orderService.CreateOrder(order);
            if (orderCreation.Item1 == true)
            {
                 
            } else
            {

            }
        }
    }

}
