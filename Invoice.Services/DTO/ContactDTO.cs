using InvoiceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class ContactDTO
    {
        public long Id { get; set; }
        public string ContactInfo { get; private set; }
        public ContactType ContactType { get; private set; }  
        public long ClientId { get; private set; }
    }
}
