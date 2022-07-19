using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<Item> SearchByTotalItem(decimal totalItem);
        Task<Item> SearchByDescription(string description);
    }
}
