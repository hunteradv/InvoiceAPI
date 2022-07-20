using InvoiceApi.Domain.Entities;
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
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly InvoiceContext _context;

        public ClientRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Client>> SearchByFirstName(string firstName)
        {
            var firstNames = await _context.Clients
                .Where(x => x.FirstName.ToLower().Contains(firstName.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return firstNames;
        }

        public virtual async Task<List<Client>> SearchByLastName(string lastName)
        {
            var lastNames = await _context.Clients
                .Where(x => x.LastName.ToLower().Contains(lastName.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return lastNames;
        }
    }
}
