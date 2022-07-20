using InvoiceApi.Domain.Entities;
using InvoiceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<Contact> GetByContactType(ContactType contactType);
        Task<List<Contact>> SearchByContactInfo(string contactInfo);
    }
}
