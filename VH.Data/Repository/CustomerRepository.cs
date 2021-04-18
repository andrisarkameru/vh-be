using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class CustomerRepository : EfCoreRepository<Customer, VHDbmodelContext>
    {
        private readonly VHDbmodelContext context;

        public CustomerRepository(VHDbmodelContext context) : base(context)
        {
            this.context = context;
        }

        public Task<Customer> GetUserByEmail(string email)
        {
            if (email == null) return null;
            var custumers = context.Customer.Where(x => x.Email.ToLower() == email.ToLower());
            return custumers.FirstOrDefaultAsync();
        }
    }
}
