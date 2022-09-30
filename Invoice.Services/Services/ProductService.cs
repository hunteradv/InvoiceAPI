using AutoMapper;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Entities;
using InvoiceApi.Infrastructure.Interfaces;
using InvoiceApi.Infrastructure.Repositories;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            var productExists = await _productRepository.Get(productDTO.Id);

            if (productExists != null)
            {
                throw new DomainException("Já existe um produto para o id informado!");
            }

            var product = _mapper.Map<Product>(productDTO);
            var productCreated = await _productRepository.Create(product);

            return _mapper.Map<ProductDTO>(productCreated);
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var productExists = await _productRepository.Get(productDTO.Id);

            if (productExists == null)
            {
                throw new DomainException("Não existe um produto para o id informado!");
            }

            var product = _mapper.Map<Product>(productDTO);
            var productCreated = await _productRepository.Update(product);

            return _mapper.Map<ProductDTO>(productCreated);
        }

        public async Task Remove(long id)
        {
            await _productRepository.Remove(id);
        }

        public async Task<ProductDTO> Get(long id)
        {
            var product = await _productRepository.Get(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> Get()
        {
            var allProducts = await _productRepository.Get();

            return _mapper.Map<List<ProductDTO>>(allProducts);
        }        

        public async Task<List<ProductDTO>> SearchByName(string name)
        {
            var allProducts = await _productRepository.SearchByName(name);

            return _mapper.Map<List<ProductDTO>>(allProducts);
        }

        public async Task<List<ProductDTO>> SearchByUnitValue(decimal unitValue)
        {
            var allProducts = await _productRepository.SearchByUnitValue(unitValue);

            return _mapper.Map<List<ProductDTO>>(allProducts);
        }        
    }
}
