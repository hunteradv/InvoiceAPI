using AutoMapper;
using InvoiceApi.Api.Utilities;
using InvoiceApi.Api.ViewModels;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Infrastructure.Context;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using InvoiceApi.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace InvoiceApi.Api.Controllers
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/invoice/create")]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceViewModel invoiceViewModel)
        {
            try
            {
                var invoiceDTO = _mapper.Map<InvoiceDTO>(invoiceViewModel);
                var invoiceCreated = await _invoiceService.Create(invoiceDTO);

                return Ok(new ResultViewModel {
                    Message = "Nota fiscal criada com sucesso!",
                    Success = true,
                    Data = null
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
        [Route("/api/v1/invoice/update")]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceViewModel invoiceViewModel)
        {
            try
            {
                var invoiceDTO = _mapper.Map<InvoiceDTO>(invoiceViewModel);
                var invoiceUpdated = await _invoiceService.Update(invoiceDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Nota fiscal atualizada com sucesso!",
                    Success = true,
                    Data = invoiceUpdated
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
        [Route("/api/v1/invoice/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _invoiceService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Nota fiscal removida com sucesso!",
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
        [Route("/api/v1/invoice/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var invoice = await _invoiceService.Get(id);

                if (invoice == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma nota fiscal foi encontrada com o Id informado",
                        Success = true,
                        Data = invoice
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Nota fiscal encontrada com sucesso!",
                    Success = true,
                    Data = invoice
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
        [Route("/api/v1/invoice/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allInvoices = await _invoiceService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Notas fiscais encontradas com sucesso!",
                    Success = true,
                    Data = allInvoices
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
