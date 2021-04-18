using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using VH.Data.EFCore;

namespace VH.Data.SeedData
{
    public class DataSeeder
    {
        private VHDbmodelContext _ctx;

        public DataSeeder(VHDbmodelContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDatabase()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            string basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SeedData");
            string assetPath = Path.Combine(basePath, "asset-incomplete.json");
            string json = System.IO.File.ReadAllText(assetPath);
            var assets = JsonConvert.DeserializeObject<List<Asset>>(json);
            _ctx.Asset.AddRange(assets);

            string customerPath = Path.Combine(basePath, "customer.json");
            json = System.IO.File.ReadAllText(customerPath);
            var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            _ctx.Customer.AddRange(customers);

            _ctx.SaveChanges();
        }
    }
}
