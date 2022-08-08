using AutoMapper;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Entities;
using InvoiceApi.Domain.Enums;
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
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly ContactRepository _contactRepository;

        public async Task<ContactDTO> Create(ContactDTO contactDTO)
        {
            var contactExists = await _contactRepository.Get(contactDTO.Id);

            if (contactExists != null)
            {
                throw new DomainException("Já existe um contato com o id informado!");
            }

            var contact = _mapper.Map<Contact>(contactDTO);

            var contactCreated = _contactRepository.Create(contact);
            return _mapper.Map<ContactDTO>(contactCreated);
        }
        public async Task<ContactDTO> Update(ContactDTO contactDTO)
        {
            var contactExists = await _contactRepository.Get(contactDTO.Id);

            if (contactExists == null)
            {
                throw new DomainException("Não existe um contato com o id informado!");
            }

            var contact = _mapper.Map<Contact>(contactDTO);
            var contactCreated = await _contactRepository.Create(contact);

            return _mapper.Map<ContactDTO>(contactCreated);
        }

        public async Task Remove(long id)
        {
            await _contactRepository.Remove(id);
        }

        public async Task<ContactDTO> Get(long id)
        {
            var contact = await _contactRepository.Get(id);

            return _mapper.Map<ContactDTO>(contact);
        }

        public async Task<List<ContactDTO>> Get()
        {
            var allContacts = await _contactRepository.Get();

            return _mapper.Map<List<ContactDTO>>(allContacts);
        }

        public async Task<List<ContactDTO>> GetByContactType(ContactType contactType)
        {
            var allContacts = await _contactRepository.GetByContactType(contactType);

            return _mapper.Map<List<ContactDTO>>(allContacts);
        }        

        public async Task<List<ContactDTO>> SearchByContactInfo(string contactInfo)
        {
            var allContacts = await _contactRepository.SearchByContactInfo(contactInfo);

            return _mapper.Map<List<ContactDTO>>(allContacts);
        }        
    }
}
