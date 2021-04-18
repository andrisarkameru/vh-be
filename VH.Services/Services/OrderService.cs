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
        private readonly AssetRepository _assetRepo;
        private readonly IMapper _mapper;

        public OrderService(
            OrderRepository orders,
            CustomerRepository customers, 
            AssetRepository assets,
            IMapper mapper)
        {
            this._orderRepo = orders;
            this._customerRepo = customers;
            this._assetRepo = assets;
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
            
            //Check asset
            var asset = await _assetRepo.Get(orderDto.Asset.Id);
            if (asset == null)
            {
                throw new ApiException("Asset not found");
            }
            else
            {
                order.Asset = asset;
            }           

            //Check if returning customer;
            var customer = await _customerRepo.GetUserByEmail(orderDto?.Customer?.Email);
            if (customer != null)
            {
                order.Customer = customer;
            }
            //Check availability:
            var availability = await CheckAvailability(orderDto);
            if (!availability)
            {
                return (false, orderDto, $"Order refused: Asset already leased for given period");
            }
            //CreateOrder;
            order.Status = OrderStatus.Active;
            var savedOrder = await _orderRepo.Add(order);
            var savedOrderDto = _mapper.Map<OrderDTO>(savedOrder);

            return (true, savedOrderDto, null);
        }
        public async Task<bool> DeleteOrder(OrderDTO order)
        {
            var orderEf = await _orderRepo.Get(order.Id);
            if (orderEf == null) throw new ApiException($"Order {order.Id} not found in database");

            await _orderRepo.Delete(order.Id);

            return true;
        }
        public async Task<(bool, OrderDTO, string)> UpdateOrder(OrderDTO order)
        {
            var orderEf = await _orderRepo.Get(order.Id);
            if (orderEf == null) throw new ApiException($"Order {order.Id} not found in database");

            //When updating order, only select fields are being updated: Dates, status

            throw new NotImplementedException();

        }

        public async Task<bool> CheckAvailability(OrderDTO order)
        {
            var result = await _orderRepo.GetAssetOrdersByDate(order.Asset.Id, order.From, order.To);

            var temp = await _orderRepo.GetAll();
            if (result?.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
