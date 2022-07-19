using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<List<Address>> SearchByCity(string city);
        Task<List<Address>> SearchByState(string state);
        Task<List<Address>> SearchByCountry(string country);
    }
}
