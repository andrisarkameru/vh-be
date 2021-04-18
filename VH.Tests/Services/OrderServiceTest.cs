using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VH.Core.Transport;
using VH.Data.EFCore;
using VH.Data.Repository;
using VH.Services;
using VH.Services.Interfaces;

namespace VH.Tests
{
    public class OrderServiceTest : ServiceTestBase
    {
        private OrderRepository repo;
        private CustomerRepository customers;
        private AssetRepository assets;
        private OrderService service;

        [SetUp]
        public void Setup()
        {
            //Seed data
            base.SeedTestLocations(_ctx);
            base.SeedTestCustomers(_ctx);
            base.SeedTestAssets(_ctx);
            base.SeedTestOrders(_ctx);

            //Create service
            repo = new OrderRepository(_ctx);
            customers = new CustomerRepository(_ctx);
            assets = new AssetRepository(_ctx);

            service = new OrderService(repo, customers, assets, _mapper);
        }

        [Test]
        public async Task ShouldTestIfOrderCanBePlaced()
        {
            var availability1 = await service.CheckAvailability(new OrderDTO() { Asset = new AssetDTO() { Id = 1 }, From = DateTimeOffset.Parse("2021-05-01"), To = DateTimeOffset.Parse("2021-05-02") });

            availability1.Should().BeFalse();

            var availability2 = await service.CheckAvailability(new OrderDTO() { Asset = new AssetDTO() { Id = 1 }, From = DateTimeOffset.Parse("2020-05-01"), To = DateTimeOffset.Parse("2020-05-02") });

            availability2.Should().BeTrue();
        }
        [Test]
        public async Task ShouldCreateOrdrer()
        {
            var order = new OrderDTO()
            {
                Asset = new AssetDTO() { Id = 1 },
                Customer = new CustomerDTO() { Email = "new-user@bb.com", Name = "User1", Age = 66 },
                From = DateTimeOffset.Parse("2022-01-01"),
                To = DateTimeOffset.Parse("2022-12-01"),
            };
            var response = await service.CreateOrder(order);
            response.Item1.Should().BeTrue();
            response.Item2.Id.Should().NotBe(0);
        }

        [Test]
        public async Task ShouldFailCreatingOrder()
        {
            var order = new OrderDTO()
            {
                Asset = new AssetDTO() { Id = 1 },
                Customer = new CustomerDTO() { Email = "new-user@bb.com", Name = "User1", Age = 66 },
                From = DateTimeOffset.Parse("2021-06-01"),
                To = DateTimeOffset.Parse("2022-12-01"),
            };
            var response = await service.CreateOrder(order);
            response.Item1.Should().BeFalse();
        }
    }
}
