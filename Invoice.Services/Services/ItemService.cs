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
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;

        public ItemService(IMapper mapper, IItemRepository itemRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _productRepository = productRepository;
        }

        public async Task<ItemDTO> Create(ItemDTO itemDTO)
        {
            var itemExists = await _itemRepository.Get(itemDTO.Id);

            if (itemExists != null)
            {
                throw new DomainException("Já existe um item com o id informado!");
            }

            var product = await _productRepository.Get(itemDTO.ProductId);
            itemDTO.UnitValue = product.UnitValue;
            itemDTO.Description = product.Name;

            var item = _mapper.Map<Item>(itemDTO);            
            var itemCreated = await _itemRepository.Create(item);

            return _mapper.Map<ItemDTO>(itemCreated);
        }

        public async Task<ItemDTO> Update(ItemDTO itemDTO)
        {
            var itemExists = await _itemRepository.Get(itemDTO.Id);

            if (itemExists == null)
            {
                throw new DomainException("Não existe um item com o id informado!");
            }

            var item = _mapper.Map<Item>(itemDTO);
            var itemCreated = await _itemRepository.Update(item);

            return _mapper.Map<ItemDTO>(itemCreated);
        }

        public async Task Remove(long id)
        {
            await _itemRepository.Remove(id);
        }

        public async Task<ItemDTO> Get(long id)
        {
            var item = await _itemRepository.Get(id);

            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<List<ItemDTO>> Get()
        {
            var allItems = await _itemRepository.Get();

            return _mapper.Map<List<ItemDTO>>(allItems);
        }
      
        public async Task<List<ItemDTO>> SearchByDescription(string description)
        {
            var allItems = await _itemRepository.SearchByDescription(description);

            return _mapper.Map<List<ItemDTO>>(allItems);
        }

        public async Task<List<ItemDTO>> SearchByTotalItem(decimal totalItem)
        {
            var allItems = await _itemRepository.SearchByTotalItem(totalItem);

            return _mapper.Map<List<ItemDTO>>(allItems);
        }        
    }
}
