using InvoiceAPI.Enums;
using InvoiceAPI.Models;

namespace InvoiceAPI.Data.Dtos.Contact
{
    public class ReadContactDto
    {
        public int Id { get; set; }
        public string ContactInfo { get; set; }
        public ContactType ContactType { get; set; }
        public Client Client { get; set; }
    }
}
