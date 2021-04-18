using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VH.Data.EFCore;

namespace VH.Tests
{
    public class ServiceTestBase
    {
        internal DbContextOptions<VHDbmodelContext> _options;
        internal IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>());
            _mapper = mapperConfig.CreateMapper();


            //Create In Memory Database
            _options = new DbContextOptionsBuilder<VHDbmodelContext>()
            .UseInMemoryDatabase(databaseName: "vhdb")
            .Options;
        }
        public void SeedTestLocations(VHDbmodelContext ctx)
        {

        }
        public void SeedTestOrders(VHDbmodelContext ctx)
        {
            ctx.Order.Add(
                    new Order()
                    {
                        AssetId = 1,
                        CustomerId = 1,
                        LocationId = 1,
                    });

            ctx.SaveChanges();
        }
        public void SeedTestAssets(VHDbmodelContext ctx)
        {
            ctx.Asset.Add(new Asset()
            {
                Id = 1,
                Type = "MotorVehicle",
                BasePrice = 66,
                Identification = "VH1233",
            });
            ctx.Asset.Add(new Asset()
            {
                Id = 2,
                Type = "MotorVehicle",
                BasePrice = 99,
                Identification = "MTZ-2231",
            });
            ctx.SaveChanges();
        }


        public void SeedTestCustomers(VHDbmodelContext ctx)
        {
            ctx.Customer.Add(new Customer()
            {
                Name = "Test User 1",
                Email = "aa@bb.com",
                Age = 55,

            });
            ctx.Customer.Add(new Customer()
            {
                Name = "Test User 2",
                Email = "aa2@bb.com",
                Age = 69,

            });
            ctx.SaveChanges();
        }
    }
}
