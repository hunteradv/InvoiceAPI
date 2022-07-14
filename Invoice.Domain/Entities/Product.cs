using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Product : Base
    {                
        public string Name { get; private set; }       
        public decimal UnitValue { get; private set; }
        public virtual List<Item> Items { get; private set; }
    }
}
