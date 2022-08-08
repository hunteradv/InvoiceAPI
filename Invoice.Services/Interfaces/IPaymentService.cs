using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDTO> Create(PaymentDTO paymentDTO);
        Task<PaymentDTO> Update(PaymentDTO paymentDTO);
        Task Remove(long id);
        Task<PaymentDTO> Get(long id);
        Task<List<PaymentDTO>> Get();
        Task<List<PaymentDTO>> SearchByDescription(string description);
        Task<List<PaymentDTO>> SearchByValue(decimal value);
        Task<List<PaymentDTO>> SearchByPaymentType(string paymentType);
    }
}
