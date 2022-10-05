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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/contact/create")]
        public async Task<IActionResult> Create([FromBody] CreateContactViewModel contactViewModel)
        {
            try
            {
                var contactDTO = _mapper.Map<ContactDTO>(contactViewModel);
                var contactCreated = await _contactService.Create(contactDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Contato criado com sucesso!",
                    Success = true,
                    Data = contactCreated
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
        [Route("/api/v1/contact/update")]
        public async Task<IActionResult> Update([FromBody] UpdateContactViewModel contactViewModel)
        {
            try
            {
                var contactDTO = _mapper.Map<ContactDTO>(contactViewModel);
                var contactUpdated = await _contactService.Update(contactDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Contato atualizado com sucesso!",
                    Success = true,
                    Data = contactUpdated
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
