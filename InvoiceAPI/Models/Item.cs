namespace InvoiceAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal UnitValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalItem { get; set; }
    }
}
