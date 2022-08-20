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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/client/create")]
        public async Task<IActionResult> Create([FromBody] CreateClientViewModel clientViewModel)
        {
            try
            {
                var clientDTO = _mapper.Map<ClientDTO>(clientViewModel);
                var clientCreated = await _clientService.Create(clientDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente criado com sucesso!",
                    Success = true,
                    Data = clientCreated
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

        //[HttpPut("id")]
        //[Route("/api/v1/client/update")]
        //public async Task<IActionResult> Update()
        //{
        //    try
        //    {
                

        //    }catch (DomainException e)
        //    {
        //        return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, Responses.ApplictationErrorMessage());
        //    }
        //}
    }
}
