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
        [Route("/api/v1/address/create")]
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

        [HttpPut]
        [Route("/api/v1/address/update")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressViewModel addressViewModel)
        {
            try
            {
                var addressDTO = _mapper.Map<AddressDTO>(addressViewModel);
                var addressUpdated = await _addressService.Update(addressDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Endereço atualizado com sucesso!",
                    Success = true,
                    Data = addressUpdated
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
        [Route("/api/v1/address/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _addressService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Endereço removido com sucesso!",
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
        [Route("/api/v1/address/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var address = await _addressService.Get(id);

                if (address == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum endereço foi encontrado com o Id informado",
                        Success = true,
                        Data = address
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Endereço encontrado com sucesso!",
                    Success = true,
                    Data = address
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
        [Route("/api/v1/address/getAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allAddresses = await _addressService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Endereços encontrados com sucesso!",
                    Success = true,
                    Data = allAddresses
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
        [Route("/api/v1/address/search-by-city")]
        public async Task<IActionResult> SearchByCity([FromQuery] string city)
        {
            try
            {
                var allAddresses = await _addressService.SearchByCity(city);

                if (allAddresses.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum endereço foi encontrado com a cidade informada.",
                        Success = true,
                        Data = allAddresses
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Endereço(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allAddresses
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
        [Route("/api/v1/address/search-by-state")]
        public async Task<IActionResult> SearchByState([FromQuery] string state)
        {
            try
            {
                var allAddresses = await _addressService.SearchByState(state);

                if (allAddresses.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum endereço foi encontrado com o estado informado.",
                        Success = true,
                        Data = allAddresses
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Endereço(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allAddresses
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
        [Route("/api/v1/address/search-by-country")]
        public async Task<IActionResult> SearchByCountry([FromQuery] string country)
        {
            try
            {
                var allAddresses = await _addressService.SearchByCity(country);

                if (allAddresses.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum endereço foi encontrado com o país informado.",
                        Success = true,
                        Data = allAddresses
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Endereço encontrado com sucesso!",
                    Success = true,
                    Data = allAddresses
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
