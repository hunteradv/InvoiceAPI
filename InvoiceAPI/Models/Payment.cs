namespace InvoiceAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string PaymentType { get; set; }
    }
}
