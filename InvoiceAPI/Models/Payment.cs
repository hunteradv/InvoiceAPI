using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string PaymentType { get; set; }
    }
}
