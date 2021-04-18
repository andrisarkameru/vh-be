using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using VH.Data.EFCore;
using VH.Services.Interfaces;

namespace VH.Tests
{
    public class OrderServiceTest : ServiceTestBase
    {
        Mock<IOrderService> orderServiceMock;
        [SetUp]
        public void Setup()
        {
            orderServiceMock = new Mock<IOrderService>();

            //Seed test data
            using (var ctx = new VHDbmodelContext(_options))
            {
                base.SeedTestAssets(ctx);
                base.SeedTestAssets(ctx);
                base.SeedTestOrders(ctx);                
            }

        }

        [Test]
        public void ShouldCreateOrdrer()
        {

        }
    }
}
