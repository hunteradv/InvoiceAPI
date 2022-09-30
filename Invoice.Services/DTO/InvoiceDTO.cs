using InvoiceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class InvoiceDTO
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public int SerialNumber { get; set; }
        public int Number { get; set; }
       
        public InvoiceStatus Status { get; set; }
        public decimal Total { get; set; }

        public InvoiceDTO()
        {}

        public InvoiceDTO(long id, long clientId, int serialNumber, int number, InvoiceStatus status, decimal total)
        {
            Id = id;
            ClientId = clientId;
            SerialNumber = serialNumber;
            Number = number;
            Status = status;
            Total = total;
        }
    }
}
