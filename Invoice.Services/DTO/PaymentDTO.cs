using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string PaymentType { get; set; }       
        public long InvoiceId { get; set; }

        public PaymentDTO()
        {}

        public PaymentDTO(int id, string description, decimal value, string paymentType, long invoiceId)
        {
            Id = id;
            Description = description;
            Value = value;
            PaymentType = paymentType;
            InvoiceId = invoiceId;
        }
    }
}
