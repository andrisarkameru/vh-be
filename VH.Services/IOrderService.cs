using System;
using System.Collections.Generic;
using System.Text;
using VH.Core.Transport;

namespace VH.Services
{
    public interface IOrderService
    {
        (bool, string) ReserveItem(DateTimeOffset from, DateTimeOffset to);
        IEnumerable<Order> ListOrders();
        Order SingleOrder();
        
        
    }
}
