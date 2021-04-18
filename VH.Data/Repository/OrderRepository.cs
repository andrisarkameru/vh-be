using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class OrderRepository : EfCoreRepository<Order, VHDbmodelContext>
    {
        private readonly VHDbmodelContext context;

        public OrderRepository(VHDbmodelContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Order>> GetAssetOrdersByDate(int assetId, DateTimeOffset from, DateTimeOffset to)
        {
            var orders = await context.Order.Where(x => x.AssetId == assetId &&
                                (from <= x.From && to >= x.From || from >= x.From && from < x.To ))
                                .ToListAsync();
            return orders;
        }
        public override async Task<Order> Get(int id)
        {
            return await context.Order
                .Include(x => x.Asset)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public override async Task<List<Order>> GetAll()
        {
            return await context.Order.Include(x=>x.Asset).Include(x=>x.Customer).ToListAsync();
        }
    }
}
