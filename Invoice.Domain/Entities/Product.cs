using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Product : Base
    {                
        public string Name { get; set; }       
        public decimal UnitValue { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
