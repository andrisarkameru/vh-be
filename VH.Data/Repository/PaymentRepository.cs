using System;
using System.Collections.Generic;
using System.Text;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class PaymentRepository : EfCoreRepository<Payment, VHDbmodelContext>
    {
        public PaymentRepository(VHDbmodelContext context) : base(context)
        {
        }
    }
}
