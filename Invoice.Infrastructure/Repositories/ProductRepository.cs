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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly InvoiceContext _context;

        public ProductRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Product>> SearchByName(string name)
        {
            var names = await _context.Products
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return names;
        }

        public virtual async Task<List<Product>> SearchByUnitValue(decimal unitValue)
        {
            var unitValues = await _context.Products
                .Where(x => x.UnitValue.ToString().ToLower().Contains(unitValue.ToString().ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return unitValues;
        }
    }
}
