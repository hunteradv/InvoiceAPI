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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/client/create")]
        public async Task<IActionResult> Create([FromBody] CreateAddressViewModel addressViewModel)
        {
            try
            {
                var addressDTO = _mapper.Map<AddressDTO>(addressViewModel);
                var addressCreated = await _addressService.Create(addressDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Endereço criado com sucesso!",
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
