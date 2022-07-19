using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> SearchByName(string name);
        Task<Product> SearchByUnitValue(decimal unitValue);
    }
}
