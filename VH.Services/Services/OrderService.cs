using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH.Core;
using VH.Core.Transport;
using VH.Data.EFCore;
using VH.Data.Repository;
using VH.Services.Interfaces;

namespace VH.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public OrderService(OrderRepository orders, CustomerRepository customers, IMapper mapper)
        {
            this._orderRepo = orders;
            this._customerRepo = customers;
            this._mapper = mapper;
        }

        public async Task<OrderDTO> GetOrder(int id)
        {
            var order = await _orderRepo.Get(id);
            return _mapper.Map<OrderDTO>(order);
        }
        public async Task<IEnumerable<OrderDTO>> ListOrders()
        {
            var orders = await _orderRepo.GetAll();
            return orders.Select(x => _mapper.Map<OrderDTO>(x));
        }

        public async Task<(bool, OrderDTO, string)> CreateOrder(OrderDTO orderDto)
        {
            //Necessery info: 
            //Customer, Asset, Dates, Check of Asset before renting;
            var order = _mapper.Map<Order>(orderDto);
            //CreateOrder;
            _orderRepo.Add(order);
            throw new NotImplementedException();
        }



        public async Task<(bool, OrderDTO, string)> UpdateOrder(OrderDTO order)
        {
            var orderEf = await _orderRepo.Get(order.Id);
            if (orderEf == null) throw new ApiException($"Order {order.Id} not found in database");
            throw new NotImplementedException();

        }

        public Task<bool> CheckAvailability(AssetDTO asset)
        {

            throw new NotImplementedException();

        }
    }
}
