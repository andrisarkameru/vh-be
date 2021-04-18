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

        public Task<List<Order>> GetAssetOrdersByDate(int assetId, DateTimeOffset from, DateTimeOffset to)
        {
            var orders = context.Order.Where(x => x.AssetId == assetId &&
                                (x.From <= from && x.To <= to || x.From >= from && x.To >= to))
                                .ToListAsync();
            return orders;
        }
    }
}
