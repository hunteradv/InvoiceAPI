using AutoMapper;
using InvoiceApi.Api.Utilities;
using InvoiceApi.Api.ViewModels;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InvoiceApi.Api.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/payment/create")]
        public async Task<IActionResult> Create([FromBody] CreatePaymentViewModel paymentViewModel)
        {
            try
            {
                var paymentDTO = _mapper.Map<PaymentDTO>(paymentViewModel);
                var paymentCreated = await _paymentService.Create(paymentDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Pagamento criado com sucesso!",
                    Success = true,
                    Data = paymentCreated
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplictationErrorMessage());
            }
        }

        [HttpPut]
        [Route("api/v1/payment/update")]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentViewModel paymentViewModel)
        {
            try
            {
                var paymentDTO = _mapper.Map<PaymentDTO>(paymentViewModel);
                var paymentUpdated = await _paymentService.Update(paymentDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Pagamento atualizado com sucesso!",
                    Success = true,
                    Data = paymentUpdated
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplictationErrorMessage());
            }
        }
    }
}
