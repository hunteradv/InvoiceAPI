using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<Contact> GetByContactType(int contactType);
        Task<List<Contact>> SearchByContactInfo(string contactInfo);
    }
}
