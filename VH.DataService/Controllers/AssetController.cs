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
    [Route("/api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IConfiguration _config;
        private readonly IAssetService _assetService;


        public AssetController(
            ILogger<AssetController> logger, 
            IAssetService assetService)
        {
            _logger = logger;
            _assetService = assetService;
        }


        [HttpGet]
        //[Route("/")]
        public async Task<IEnumerable<AssetDTO>> Get()
        {
            var result = await _assetService.ListAssets();
            
            return result;

        }
        
    }
}
