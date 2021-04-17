using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;

namespace VH.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDTO> CalculatePayment(OrderDTO order);
        Task<PaymentDTO> CalculateForeignPayment(OrderDTO order, string currency);
    }
}
