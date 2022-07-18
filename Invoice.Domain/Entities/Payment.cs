using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Domain.Entities
{
    public class Payment : Base
    {               
        public string Description { get; private set; }        
        public decimal Value { get; private set; }        
        public string PaymentType { get; private set; }
        public virtual Invoice Invoice { get; private set; }        
        public int InvoiceId { get; private set; }
    }
}
