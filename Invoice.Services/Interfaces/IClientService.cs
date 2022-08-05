using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO> Create(ClientDTO clientDTO);
        Task<ClientDTO> Update(ClientDTO clientDTO);
        Task Remove(long id);
        Task<ClientDTO> Get(long id);
        Task<List<ClientDTO>> Get();
        Task<List<ClientDTO>> SearchByFirstName(string firstName);
        Task<List<ClientDTO>> SearchByLastName(string lastName);
    }
}
