using InvoiceApi.Domain.Enums;
using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceDTO> Create(InvoiceDTO invoiceDTO);
        Task<InvoiceDTO> Update(InvoiceDTO invoiceDTO);
        Task Remove(long id);
        Task<InvoiceDTO> Get(long id);
        Task<List<InvoiceDTO>> Get();
        Task<List<InvoiceDTO>> GetBySerialNumber(int serialNumber);
        Task<List<InvoiceDTO>> SearchByNumber(int number);
        Task<List<InvoiceDTO>> GetByStatus(InvoiceStatus status);
        Task<List<InvoiceDTO>> SearchByTotal(decimal total);
    }
}
