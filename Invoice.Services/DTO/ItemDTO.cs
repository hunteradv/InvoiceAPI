using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class ItemDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal UnitValue { get; set; }
        public int Quantity { get; set; } 
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }

        public ItemDTO()
        {}

        public ItemDTO(long id, string description, decimal unitValue, int quantity, long invoiceId, long productId)
        {
            Id = id;
            Description = description;
            UnitValue = unitValue;
            Quantity = quantity;
            InvoiceId = invoiceId;
            ProductId = productId;
        }
    }
}
