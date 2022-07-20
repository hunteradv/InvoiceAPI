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
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly InvoiceContext _context;

        public AddressRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Address>> SearchByCity(string city)
        {
            var cities = await _context.Addresses
                .Where(x => x.City.ToLower().Contains(city.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return cities;
        }

        public virtual async Task<List<Address>> SearchByCountry(string country)
        {
            var countries = await _context.Addresses
                .Where(x => x.Country.ToLower().Contains(country.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return countries;
        }

        public virtual async Task<List<Address>> SearchByState(string state)
        {
            var states = await _context.Addresses
                .Where(x => x.State.ToLower().Contains(state.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return states;
        }
    }
}
