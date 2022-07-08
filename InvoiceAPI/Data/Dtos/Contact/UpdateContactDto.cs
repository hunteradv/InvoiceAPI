using InvoiceAPI.Enums;

namespace InvoiceAPI.Data.Dtos.Contact
{
    public class UpdateContactDto
    {
        public string ContactInfo { get; set; }
        public ContactType ContactType { get; set; }
        public int ClientId { get; set; }
    }
}
