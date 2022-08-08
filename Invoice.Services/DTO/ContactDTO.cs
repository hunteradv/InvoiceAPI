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
        public string ContactInfo { get; set; }
        public ContactType ContactType { get; set; }  
        public long ClientId { get; set; }

        public ContactDTO()
        {}

        public ContactDTO(long id, string contactInfo, ContactType contactType, long clientId)
        {
            Id = id;
            ContactInfo = contactInfo;
            ContactType = contactType;
            ClientId = clientId;
        }
    }
}
