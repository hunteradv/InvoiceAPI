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
        Task<List<Payment>> SearchByDescription(string description);
        Task<List<Payment>> SearchByValue(decimal value);
        Task<List<Payment>> SearchByPaymentType(string paymentType);
    }
}
