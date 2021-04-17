using System;
using System.Collections.Generic;
using System.Text;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class OrderRepository : EfCoreRepository<Order, VHDbmodelContext>
    {
        public OrderRepository(VHDbmodelContext context) : base(context)
        {
        }
    }
}
