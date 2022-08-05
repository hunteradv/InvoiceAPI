using InvoiceApi.Domain.Enums;
using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactDTO> Create(ContactDTO contactDTO);
        Task<ContactDTO> Update(ContactDTO contactDTO);
        Task Remove(long id);
        Task<ContactDTO> Get(long id);
        Task<List<ContactDTO>> Get();
        Task<List<ContactDTO>> GetByContactType(ContactType contactType);
        Task<List<ContactDTO>> SearchByContactInfo(string contactInfo);
    }
}
