﻿using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Interfaces
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task<Invoice> GetBySerialNumber(int serialNumber);
        Task<List<Invoice>> SearchByNumber(int number);
        Task<List<Invoice>> SearchByTotal(decimal total);
    }
}
