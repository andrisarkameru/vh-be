using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;
using VH.Data.EFCore;
using VH.Services.Interfaces;

namespace VH.Services
{
    public class OrderService : IOrderService
    {
        protected readonly VHDbmodelContext ctx;

        public OrderService(VHDbmodelContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO order)
        {
            RentableItem a = new RentableItem();
            ctx.RentableItem.Add(a);
            await ctx.SaveChangesAsync();

            var newOrder = new Order()
            {
                CustomerId = 1
            };
            ctx.Order.Add(newOrder);
            await ctx.SaveChangesAsync();
            return new OrderDTO();
        }

        public async Task<IEnumerable<OrderDTO>> ListOrders()
        {
            return (await ctx.Order.ToListAsync()).Select(x => new OrderDTO() { Id = x.Id });
        }

        public (bool, string) ReserveItem(DateTimeOffset from, DateTimeOffset to)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> UpdateOrder(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        Task<OrderDTO> IOrderService.SingleOrder()
        {
            throw new NotImplementedException();
        }
    }
}
