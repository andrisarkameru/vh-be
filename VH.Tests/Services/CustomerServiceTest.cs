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
        private CustomerRepository repo;

        [SetUp]
        public void Setup()
        {
            //Seed test data
            base.SeedTestCustomers(_ctx);
            repo = new CustomerRepository(_ctx);
        }
        [Test]
        public async Task ShouldGetCustomerByEmail()
        {

            var user = await repo.GetUserByEmail("AA@bb.com");
            user.Should().NotBeNull().And.BeEquivalentTo(new Customer() { Id = 1, Email = "aa@bb.com", Age = 55, Name = "Test User 1" });


            var user2 = await repo.GetUserByEmail("not-existing-email@bb.com");
            user2.Should().BeNull();
        }
    }
}
