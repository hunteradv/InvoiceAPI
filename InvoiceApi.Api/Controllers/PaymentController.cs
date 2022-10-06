using AutoMapper;
using InvoiceApi.Api.Utilities;
using InvoiceApi.Api.ViewModels;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using InvoiceApi.Services.Services;
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

        [HttpDelete]
        [Route("/api/v1/payment/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _paymentService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Pagamento removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplictationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/payment/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var payment = await _paymentService.Get(id);

                if (payment == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum pagamento foi encontrado com o Id informado",
                        Success = true,
                        Data = payment
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Pagamento encontrado com sucesso!",
                    Success = true,
                    Data = payment
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

        [HttpGet]
        [Route("/api/v1/payment/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allPayments = await _paymentService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Pagamentos encontrados com sucesso!",
                    Success = true,
                    Data = allPayments
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

        [HttpGet]
        [Route("/api/v1/item/search-by-payment-description")]
        public async Task<IActionResult> SearchByDescription([FromQuery] string description)
        {
            try
            {
                var allPayments = await _paymentService.SearchByDescription(description);

                if (allPayments.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum pagamento foi encontrado com a descrição informada.",
                        Success = true,
                        Data = allPayments
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Pagamentos(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allPayments
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

        [HttpGet]
        [Route("/api/v1/payment/search-by-payment-type")]
        public async Task<IActionResult> SearchByPaymentType([FromQuery] string paymentType)
        {
            try
            {
                var allPayments = await _paymentService.SearchByPaymentType(paymentType);

                if (allPayments.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum pagamento foi encontrado com o tipo informado.",
                        Success = true,
                        Data = allPayments
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Pagamentos(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allPayments
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

        [HttpGet]
        [Route("/api/v1/payment/search-by-value")]
        public async Task<IActionResult> SearchByValue([FromQuery] decimal value)
        {
            try
            {
                var allPayments = await _paymentService.SearchByValue(value);

                if (allPayments.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum pagamento foi encontrado com o tipo informado.",
                        Success = true,
                        Data = allPayments
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Pagamentos(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allPayments
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
