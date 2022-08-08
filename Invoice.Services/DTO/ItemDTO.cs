using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class ItemDTO
    {
        public string Description { get; set; }
        public decimal UnitValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalItem { get; set; }        
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }

        public ItemDTO()
        {}

        public ItemDTO(string description, decimal unitValue, int quantity, decimal totalItem, long invoiceId, long productId)
        {
            Description = description;
            UnitValue = unitValue;
            Quantity = quantity;
            TotalItem = totalItem;
            InvoiceId = invoiceId;
            ProductId = productId;
        }
    }
}
