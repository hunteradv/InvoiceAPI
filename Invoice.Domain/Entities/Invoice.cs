using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Invoice : Base
    {        
        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }        
        public int SerialNumber { get; private set; }        
        public int Number { get; private set; }        
        public decimal Total { get; private set; }
        public virtual List<Payment> Payments { get; private set; }
        public virtual List<Item> Items { get; private set; }
    }
}
