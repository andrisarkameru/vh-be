using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;

namespace VH.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrder(int id);
        Task<IEnumerable<OrderDTO>> ListOrders();
        Task<bool> CheckAvailability(OrderDTO asset);
        Task<(bool, OrderDTO, string)> CreateOrder(OrderDTO order);
        Task<bool> DeleteOrder(OrderDTO order);
        Task<(bool, OrderDTO, string)> UpdateOrder(OrderDTO order);
    }
}
