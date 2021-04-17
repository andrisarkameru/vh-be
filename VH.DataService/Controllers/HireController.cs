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
    public class HireController : ControllerBase
    {
        private readonly ILogger<HireController> _logger;
        private readonly IConfiguration _config;
        private readonly ICurrencyService _currencyService;
        private readonly IOrderService _orderService;


        public HireController(
            ILogger<HireController> logger, 
            IConfiguration config, 
            ICurrencyService currencyService,
            IOrderService orderService)
        {
            _logger = logger;
            _config = config;
            _currencyService = currencyService;
            _orderService = orderService;

        }


        [HttpGet]
        //[Route("/")]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            await _orderService.CreateOrder(new OrderDTO());
            var result =  await _orderService.ListOrders();
            return result;

        }
        
    }
}
