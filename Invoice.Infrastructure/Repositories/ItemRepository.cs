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
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public readonly InvoiceContext _context;

        public ItemRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Item>> SearchByDescription(string description)
        {
            var descriptions = await _context.Items
                .Where(x => x.Description.ToLower().Contains(description.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return descriptions;
        }

        public async Task<List<Item>> SearchByTotalItem(decimal totalItem)
        {
            var totalItems = await _context.Items
                .Where(x => x.TotalItem.ToString().ToLower().Contains(totalItem.ToString()))
                .AsNoTracking()
                .ToListAsync();

            return totalItems;
        }
    }
}
