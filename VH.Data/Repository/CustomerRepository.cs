using System;
using System.Collections.Generic;
using System.Text;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class CustomerRepository : EfCoreRepository<Customer, VHDbmodelContext>
    {
        public CustomerRepository(VHDbmodelContext context) : base(context)
        {
        }
    }
}
