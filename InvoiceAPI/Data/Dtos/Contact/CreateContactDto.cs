using InvoiceAPI.Enums;
using InvoiceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Data.Dtos.Contact
{
    public class CreateContactDto
    {               
        public string ContactInfo { get; set; }        
        public ContactType ContactType { get; set; }        
        public int ClientId { get; set; }
    }
}
