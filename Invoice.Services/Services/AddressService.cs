using AutoMapper;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Entities;
using InvoiceApi.Infrastructure.Interfaces;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<AddressDTO> Create(AddressDTO addressDTO)
        {
            var addressExists = await _addressRepository.Get(addressDTO.Id);

            if (addressExists != null)
            {
                throw new DomainException("Não existe nenhum endereço com o id informado!");
            }

            var address = _mapper.Map<Address>(addressDTO);
            address.Validate();

            var addressCreated = await _addressRepository.Create(address);

            return _mapper.Map<AddressDTO>(addressCreated);
        }

        public async Task<AddressDTO> Update(AddressDTO addressDTO)
        {
            var addressExists = await _addressRepository.Get(addressDTO.Id);

            if (addressExists != null)
            {
                throw new DomainException("Não existe nenhum endereço com o id informado!");
            }

            var address = _mapper.Map<Address>(addressDTO);
            address.Validate();

            var addressUpdated = await _addressRepository.Update(address);

            return _mapper.Map<AddressDTO>(addressUpdated);
        }

        public async Task Remove(long id)
        {
            await _addressRepository.Remove(id);
        }

        public async Task<AddressDTO> Get(long id)
        {
            var address = await _addressRepository.Get(id);

            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<List<AddressDTO>> Get()
        {
            var allAddresses = await _addressRepository.Get();

            return _mapper.Map<List<AddressDTO>>(allAddresses);
        }

        public async Task<List<AddressDTO>> SearchByCity(string city)
        {
            var allAddresses = await _addressRepository.SearchByCity(city);

            return _mapper.Map<List<AddressDTO>>(allAddresses);
        }

        public async Task<List<AddressDTO>> SearchByCountry(string country)
        {
            var allCountries = await _addressRepository.SearchByCountry(country);

            return _mapper.Map<List<AddressDTO>>(allCountries);
        }

        public async Task<List<AddressDTO>> SearchByState(string state)
        {
            var allStates = await _addressRepository.SearchByState(state);

            return _mapper.Map<List<AddressDTO>>(allStates);
        }
    }
}
