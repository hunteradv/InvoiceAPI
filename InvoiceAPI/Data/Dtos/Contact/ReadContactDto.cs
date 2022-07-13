using InvoiceAPI.Enums;
using InvoiceAPI.Models;
using System;

namespace InvoiceAPI.Data.Dtos.Contacts
{
    public class ReadContactDto
    {
        public int Id { get; set; }
        public string ContactInfo { get; set; }
        public ContactType ContactType { get; set; }
        public virtual Client Client { get; set; }
    }
}
