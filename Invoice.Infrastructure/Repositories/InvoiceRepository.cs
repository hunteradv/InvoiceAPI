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

    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public readonly InvoiceContext _context;

        public InvoiceRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Invoice>> GetBySerialNumber(int serialNumber)
        {
            var serial = await _context.Invoices
                .Where(x => x.SerialNumber == serialNumber)
                .AsNoTracking()
                .ToListAsync();

            return serial;
        }

        public virtual async Task<List<Invoice>> SearchByNumber(int number)
        {
            var numbers = await _context.Invoices
                .Where(x => x.Number.ToString().ToLower().Contains(number.ToString().ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return numbers;
        }

        public virtual async Task<List<Invoice>> GetByStatus(InvoiceStatus status)
        {
            var invoiceStatus = await _context.Invoices
                .Where(x => x.Status == status)
                .AsNoTracking()
                .ToListAsync();

            return invoiceStatus;
        }

        public virtual async Task<List<Invoice>> SearchByTotal(decimal total)
        {
            var invoiceTotal = await _context.Invoices
                .Where(x => x.Total.ToString().ToLower().Contains(total.ToString().ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return invoiceTotal;
        }
    }
}
