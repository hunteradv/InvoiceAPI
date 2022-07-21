using InvoiceApi.Domain.Entities;
using InvoiceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task<List<Invoice>> GetBySerialNumber(int serialNumber);
        Task<List<Invoice>> SearchByNumber(int number);
        Task<List<Invoice>> GetByStatus (InvoiceStatus status);
        Task<List<Invoice>> SearchByTotal(decimal total);
    }
}
