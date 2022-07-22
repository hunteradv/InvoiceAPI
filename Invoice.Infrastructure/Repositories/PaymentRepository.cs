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
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly InvoiceContext _context;

        public PaymentRepository(InvoiceContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Payment>> SearchByDescription(string description)
        {
            var descriptions = await _context.Payments
                .Where(x => x.Description.ToLower().Contains(description.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return descriptions;
        }

        public virtual async Task<List<Payment>> SearchByPaymentType(string paymentType)
        {
            var payments = await _context.Payments
                .Where(x => x.PaymentType.ToLower().Contains(paymentType.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return payments;
        }

        public virtual async Task<List<Payment>> SearchByValue(decimal value)
        {
            var values = await _context.Payments
                .Where(x => x.Value.ToString().ToLower().Contains(value.ToString().ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return values;
        }
    }
}
