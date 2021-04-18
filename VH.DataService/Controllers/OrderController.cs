using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VH.Core;
using VH.Core.Transport;
using VH.Currency;
using VH.Services.Interfaces;

namespace VH.DataService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
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
        [Route("/api/[controller]/orders/")]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            return await _orderService.ListOrders();
        }

        //Get 
        [HttpGet]
        [Route("/api/[controller]/orders/{id:int}")]
        public async Task<OrderDTO> Get(int id)
        {
            return await _orderService.GetOrder(id);
        }


        /// <summary>
        /// Create a booking order for hire
        /// </summary>
        /// <param name="order"></param>
        /// <returns>200 and order information, or 400 and error message</returns>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder([FromBody] OrderDTO order)
        {
            try
            {
                var orderCreation = await _orderService.CreateOrder(order);
                if (orderCreation.Item1 == true)
                {
                    return Ok(orderCreation.Item2);
                }
                else
                {
                    return BadRequest(orderCreation.Item3);
                }
            }
            catch (ApiException e)
            {

                return BadRequest(e.UserMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> UpdateOrder([FromBody] OrderDTO order)
        {
            try
            {
                var orderUpdate = await _orderService.UpdateOrder(order);
                if (orderUpdate.Item1 == true)
                {
                    return Ok(orderUpdate.Item2);
                }
                else
                {
                    return BadRequest(orderUpdate.Item3);
                }
            }
            catch (ApiException e)
            {

                return BadRequest(e.UserMessage);
            }
        }



    }

}
