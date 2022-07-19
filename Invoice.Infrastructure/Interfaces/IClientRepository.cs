using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<List<Client>> SearchByFirstName(string firstName);
        Task<List<Client>> SearchByLastName(string lastName);
    }
}
