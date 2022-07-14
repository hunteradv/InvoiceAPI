using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Item : Base
    {
        public string Description { get; private set; }        
        public decimal UnitValue { get; private set; }        
        public int Quantity { get; private set; }        
        public decimal TotalItem { get; private set; }
        public virtual Invoice Invoice { get; private set; }        
        public int InvoiceId { get; private set; }
        public virtual Product Product { get; private set; }        
        public int ProductId { get; private set; }
    }
}
