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

        [HttpPut]
        [Route("/api/v1/client/update")]
        public async Task<IActionResult> Update([FromBody] UpdateClientViewModel clientViewModel)
        {
            try
            {
                var clientDTO = _mapper.Map<ClientDTO>(clientViewModel);
                var clientUpdated = await _clientService.Update(clientDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente atualizado com sucesso!",
                    Success = true,
                    Data = clientUpdated
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
        [Route("/api/v1/client/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _clientService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente removido com sucesso!",
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
        [Route("/api/v1/client/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var client = await _clientService.Get(id);

                if (client == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum cliente foi encontrado com o Id informado",
                        Success = true,
                        Data = client
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Cliente encontrado com sucesso!",
                    Success = true,
                    Data = client
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
