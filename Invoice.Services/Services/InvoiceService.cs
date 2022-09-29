using AutoMapper;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Entities;
using InvoiceApi.Domain.Enums;
using InvoiceApi.Infrastructure.Interfaces;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<InvoiceDTO> Create(InvoiceDTO invoiceDTO)
        {
            var invoiceExists = await _invoiceRepository.Get(invoiceDTO.Id);

            if (invoiceExists != null)
            {
                throw new DomainException("Já existe uma nota fiscal para o id informado!");
            }

            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            var invoiceCreated = await _invoiceRepository.Create(invoice);

            return _mapper.Map<InvoiceDTO>(invoiceCreated);
        }

        public async Task<InvoiceDTO> Update(InvoiceDTO invoiceDTO)
        {
            var invoiceExists = await _invoiceRepository.Get(invoiceDTO.Id);

            if (invoiceExists == null)
            {
                throw new DomainException("Não existe uma nota fiscal para o id informado!");
            }

            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            var invoiceUpdated = await _invoiceRepository.Update(invoice);

            return _mapper.Map<InvoiceDTO>(invoiceUpdated);
        }

        public async Task Remove(long id)
        {
            await _invoiceRepository.Remove(id);
        }

        public async Task<InvoiceDTO> Get(long id)
        {
            var invoice = await _invoiceRepository.Get(id);

            return _mapper.Map<InvoiceDTO>(invoice);
        }

        public async Task<List<InvoiceDTO>> Get()
        {
            var allInvoices = await _invoiceRepository.Get();

            return _mapper.Map<List<InvoiceDTO>>(allInvoices);
        }

        public async Task<List<InvoiceDTO>> GetBySerialNumber(int serialNumber)
        {
            var allInvoices = await _invoiceRepository.GetBySerialNumber(serialNumber);

            return _mapper.Map<List<InvoiceDTO>>(allInvoices);
        }

        public async Task<List<InvoiceDTO>> GetByStatus(InvoiceStatus status)
        {
            var allInvoices = await _invoiceRepository.GetByStatus(status);

            return _mapper.Map<List<InvoiceDTO>>(allInvoices);
        }

        public async Task<List<InvoiceDTO>> SearchByNumber(int number)
        {
            var allInvoices = await _invoiceRepository.SearchByNumber(number);

            return _mapper.Map<List<InvoiceDTO>>(allInvoices);
        }

        public async Task<List<InvoiceDTO>> SearchByTotal(decimal total)
        {
            var allInvoices = await _invoiceRepository.SearchByTotal(total);

            return _mapper.Map<List<InvoiceDTO>>(allInvoices);
        }
    }
}
