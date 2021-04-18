using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Data.EFCore;
using VH.Data.Repository;

namespace VH.Tests
{
    public class CustomerServiceTest : ServiceTestBase
    {
        [SetUp]
        public void Setup()
        {
            //Seed test data
            using (var ctx = new VHDbmodelContext(_options))
            {
                base.SeedTestCustomers(ctx);
            }
        }
        [Test]
        public async Task ShouldGetCustomerByEmail()
        {
            using (var ctx = new VHDbmodelContext(_options))
            {
                CustomerRepository repo = new CustomerRepository(ctx);
                var user = await repo.GetUserByEmail("AA@bb.com");
                user.Should().NotBeNull().And.BeEquivalentTo(new Customer() { Id=1,  Email = "aa@bb.com", Age = 55, Name = "Test User 1" });


                var user2 = await repo.GetUserByEmail("not-existing-email@bb.com");
                user2.Should().BeNull();

            }
        }
    }
}
