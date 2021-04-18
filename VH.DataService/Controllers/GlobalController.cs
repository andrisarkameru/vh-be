using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VH.Data.EFCore;
using VH.Data.SeedData;

namespace VH.DataService.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GlobalController : ControllerBase
    {
        private VHDbmodelContext _ctx;

        public GlobalController(VHDbmodelContext ctx)
        {
            _ctx = ctx;
        }
        [Route("/admin/seed")]
        public async Task<string> SeedData()
        {            
            DataSeeder seeder = new DataSeeder(_ctx);
            seeder.SeedDatabase();

            return "Ok";
        }
    }
}
