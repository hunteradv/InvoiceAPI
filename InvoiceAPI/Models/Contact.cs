namespace InvoiceAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactInfo { get; set; }
        public ContactType ContactType { get; set; }
    }
}