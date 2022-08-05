using AutoMapper;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Entities;
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
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly ClientRepository _clientRepository;

        public ClientService(IMapper mapper, ClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDTO> Create(ClientDTO clientDTO)
        {
            var clientExists = await _clientRepository.Get(clientDTO.Id);

            if (clientExists != null)
            {
                throw new DomainException("Já existe um cliente com o id informado!");
            }

            var client = _mapper.Map<Client>(clientDTO);
            client.Validate();

            var clientCreated = await _clientRepository.Create(client);

            return _mapper.Map<ClientDTO>(clientCreated);
        }

        public async Task<ClientDTO> Update(ClientDTO clientDTO)
        {
            var clientExists = await _clientRepository.Get(clientDTO.Id);

            if (clientExists != null)
            {
                throw new DomainException("Não existe um cliente com o id informado!");
            }

            var client = _mapper.Map<Client>(clientDTO);
            client.Validate();

            var clientCreated = _clientRepository.Create(client);

            return _mapper.Map<ClientDTO>(clientCreated);
        }

        public async Task Remove(long id)
        {
            await _clientRepository.Remove(id);
        }

        public async Task<ClientDTO> Get(long id)
        {
            var client = await _clientRepository.Get(id);

            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<List<ClientDTO>> Get()
        {
            var allClients = await _clientRepository.Get();

            return _mapper.Map<List<ClientDTO>>(allClients);
        }
     
        public async Task<List<ClientDTO>> SearchByFirstName(string firstName)
        {
            var allClients = await _clientRepository.SearchByFirstName(firstName);

            return _mapper.Map<List<ClientDTO>>(allClients);
        }

        public async Task<List<ClientDTO>> SearchByLastName(string lastName)
        {
            var allClients = await _clientRepository.SearchByLastName(lastName);

            return _mapper.Map<List<ClientDTO>>(allClients);
        }        
    }
}
