using InvoiceAPI.Models;
using System.Collections.Generic;

namespace InvoiceAPI.Data.Dtos.Clients
{
    public class ReadClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
