using InvoiceApi.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<ProductDTO> Update(ProductDTO productDTO);
        Task Remove(long id);
        Task<ProductDTO> Get(long id);
        Task<List<ProductDTO>> Get();
        Task<List<ProductDTO>> SearchByName(string name);
        Task<List<ProductDTO>> SearchByUnitValue(decimal unitValue);
    }
}
