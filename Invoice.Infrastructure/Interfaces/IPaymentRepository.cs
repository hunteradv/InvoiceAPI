using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<Payment> SearchByDescription(string description);
        Task<Payment> SearchByValue(decimal value);
        Task<Payment> SearchByPaymentType(string paymentType);
    }
}
