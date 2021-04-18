using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;
using VH.Services.Interfaces;

namespace VH.Services.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentDTO> CalculateForeignPayment(OrderDTO order, string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentDTO> CalculatePayment(OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
