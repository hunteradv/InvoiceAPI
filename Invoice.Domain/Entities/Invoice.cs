using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Invoice : Base
    {        
        public virtual Client Client { get; set; }        
        public int ClientId { get; set; }        
        public int SerialNumber { get; set; }        
        public int Number { get; set; }        
        public decimal Total { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
