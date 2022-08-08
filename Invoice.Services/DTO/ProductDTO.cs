using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal UnitValue { get; set; }

        public ProductDTO()
        {}

        public ProductDTO(long id, string name, decimal unitValue)
        {
            Id = id;
            Name = name;
            UnitValue = unitValue;
        }
    }
}
