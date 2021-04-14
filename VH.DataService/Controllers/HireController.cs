using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VH.Currency;
using VH.Data.EFCore;

namespace VH.DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HireController : ControllerBase
    {
        private readonly ILogger<HireController> _logger;
        private readonly IConfiguration _config;
        private ICurrencyService _currencyService;

        public HireController(ILogger<HireController> logger, IConfiguration config, ICurrencyService currencyService)
        {
            _logger = logger;
            _config = config;
            _currencyService = currencyService;

        }


        [HttpGet]
        [Route("/")]
        public async Task<string> Get()
        {
            //var result = await _currencyService.Convert(4, "EUR", "USD");
            //return @$"
            //    {this._config["CurrencyApiKey"]}
            //    {result}
            //    {this._config["CurrencyBaseUrl"]}";
            return "AAA";

        }
        
    }
}
