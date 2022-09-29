using AutoMapper;
using InvoiceApi.Api.Utilities;
using InvoiceApi.Api.ViewModels;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Infrastructure.Context;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
