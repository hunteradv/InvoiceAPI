using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDTO> Create(AddressDTO addressDTO);
        Task<AddressDTO> Update(AddressDTO addressDTO);
        Task Remove(long id);
        Task<AddressDTO> Get(long id);
        Task<List<AddressDTO>> Get();
        Task<List<AddressDTO>> SearchByCity(string city);
        Task<List<AddressDTO>> SearchByState(string state);
        Task<List<AddressDTO>> SearchByCountry(string country);
    }
}
