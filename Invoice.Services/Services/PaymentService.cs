using AutoMapper;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Entities;
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
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, PaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentDTO> Create(PaymentDTO paymentDTO)
        {
            var paymentExists = await _paymentRepository.Get(paymentDTO.Id);

            if (paymentExists != null)
            {
                throw new DomainException("Já existe um pagamento para o id informado!");
            }

            var payment = _mapper.Map<Payment>(paymentDTO);
            var paymentCreated = await _paymentRepository.Create(payment);

            return _mapper.Map<PaymentDTO>(paymentCreated);
        }

        public async Task<PaymentDTO> Update(PaymentDTO paymentDTO)
        {
            var paymentExists = await _paymentRepository.Get(paymentDTO.Id);

            if (paymentExists == null)
            {
                throw new DomainException("Não existe um pagamento para o id informado!");
            }

            var payment = _mapper.Map<Payment>(paymentDTO);
            var paymentUpdated = await _paymentRepository.Update(payment);

            return _mapper.Map<PaymentDTO>(paymentUpdated);
        }

        public async Task Remove(long id)
        {
            await _paymentRepository.Remove(id);
        }

        public async Task<PaymentDTO> Get(long id)
        {
            var payment = await _paymentRepository.Get(id);

            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<List<PaymentDTO>> Get()
        {
            var allPayments = await _paymentRepository.Get();

            return _mapper.Map<List<PaymentDTO>>(allPayments);
        }
       
        public async Task<List<PaymentDTO>> SearchByDescription(string description)
        {
            var allPayments = await _paymentRepository.SearchByDescription(description);

            return _mapper.Map<List<PaymentDTO>>(allPayments);
        }

        public async Task<List<PaymentDTO>> SearchByPaymentType(string paymentType)
        {
            var allPayments = await _paymentRepository.SearchByPaymentType(paymentType);

            return _mapper.Map<List<PaymentDTO>>(allPayments);
        }

        public async Task<List<PaymentDTO>> SearchByValue(decimal value)
        {
            var allPayments = await _paymentRepository.SearchByValue(value);

            return _mapper.Map<List<PaymentDTO>>(allPayments);
        }        
    }
}
