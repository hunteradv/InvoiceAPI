using InvoiceApi.Domain.Entities;
using InvoiceApi.Domain.Enums;
using InvoiceApi.Infrastructure.Context;
using InvoiceApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly InvoiceContext _context;

        public ContactRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetByContactType(ContactType contactType)
        {
            var contacts = await _context.Contacts
                .Where(x => x.ContactType == contactType)
                .AsNoTracking()
                .ToListAsync();

            return contacts;
        }

        public async Task<List<Contact>> SearchByContactInfo(string contactInfo)
        {
            var contacts = await _context.Contacts
                .Where(x => x.ContactInfo.ToLower().Contains(contactInfo.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return contacts;               
        }
    }
}
