using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;

namespace VH.Services.Interfaces
{
    public interface IOrderService
    {
        (bool, string) ReserveItem(DateTimeOffset from, DateTimeOffset to);
        Task<IEnumerable<OrderDTO>> ListOrders();
        Task<OrderDTO> SingleOrder();

        Task<OrderDTO> CreateOrder(OrderDTO order);
        Task<OrderDTO> UpdateOrder(OrderDTO order);
        
        
    }
}
