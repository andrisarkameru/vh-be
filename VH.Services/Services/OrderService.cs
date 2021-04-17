using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;
using VH.Data.EFCore;
using VH.Data.Repository;
using VH.Services.Interfaces;

namespace VH.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _ordersRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public OrderService(OrderRepository orders, CustomerRepository customers, IMapper mapper)
        {
            this._ordersRepo = orders;
            this._customerRepo = customers;
            this._mapper = mapper;
        }


        public async Task<IEnumerable<OrderDTO>> ListOrders()
        {
            var orders = await _ordersRepo.GetAll();
            return orders.Select(x => _mapper.Map<OrderDTO>(x));
        }

        public async Task<(bool, OrderDTO, string)> CreateOrder(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDTO> GetOrder(int id)
        {
            var order = await _ordersRepo.Get(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<(bool, OrderDTO, string)> UpdateOrder(OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
