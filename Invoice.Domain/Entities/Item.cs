using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Item : Base
    {
        public string Description { get; set; }        
        public decimal UnitValue { get; set; }        
        public int Quantity { get; set; }        
        public decimal TotalItem { get; set; }
        public virtual Invoice Invoice { get; set; }        
        public int InvoiceId { get; set; }
        public virtual Product Product { get; set; }        
        public int ProductId { get; set; }
    }
}
