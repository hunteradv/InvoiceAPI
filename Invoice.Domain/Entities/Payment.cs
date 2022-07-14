using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Payment : Base
    {               
        public string Description { get; set; }        
        public decimal Value { get; set; }        
        public string PaymentType { get; set; }
        public virtual Invoice Invoice { get; set; }        
        public int InvoiceId { get; set; }
    }
}
