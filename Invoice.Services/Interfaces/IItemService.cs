using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemDTO> Create(ItemDTO itemDTO);
        Task<ItemDTO> Update(ItemDTO itemDTO);
        Task Remove(long id);
        Task<ItemDTO> Get(long id);
        Task<List<ItemDTO>> Get();
        Task<List<ItemDTO>> SearchByDescription(string description);
        Task<List<ItemDTO>> SearchByTotalItem(decimal totalItem);
    }
}
