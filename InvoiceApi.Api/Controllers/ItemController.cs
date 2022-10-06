using AutoMapper;
using InvoiceApi.Api.Utilities;
using InvoiceApi.Api.ViewModels;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using InvoiceApi.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InvoiceApi.Api.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/item/create")]
        public async Task<IActionResult> Create([FromBody] CreateItemViewModel itemViewModel)
        {
            try
            {
                var itemDTO = _mapper.Map<ItemDTO>(itemViewModel);
                var itemCreated = await _itemService.Create(itemDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Item criado com sucesso!",
                    Success = true,
                    Data = itemCreated
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
        [Route("api/v1/item/update")]
        public async Task<IActionResult> Update([FromBody] UpdateItemViewModel itemViewModel)
        {
            try
            {
                var itemDTO = _mapper.Map<ItemDTO>(itemViewModel);
                var itemUpdated = await _itemService.Update(itemDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Item atualizado com sucesso!",
                    Success = true,
                    Data = itemUpdated
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
        [Route("/api/v1/item/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _itemService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Item removido com sucesso!",
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
        [Route("/api/v1/item/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var item = await _itemService.Get(id);

                if (item == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum item foi encontrado com o Id informado",
                        Success = true,
                        Data = item
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Item encontrado com sucesso!",
                    Success = true,
                    Data = item
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
        [Route("/api/v1/item/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allItems = await _itemService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Itens encontrados com sucesso!",
                    Success = true,
                    Data = allItems
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
        [Route("/api/v1/item/search-by-item-description")]
        public async Task<IActionResult> SearchByDescription([FromQuery] string description)
        {
            try
            {
                var allItems = await _itemService.SearchByDescription(description);

                if (allItems.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum item foi encontrado com a descrição informada.",
                        Success = true,
                        Data = allItems
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Item(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allItems
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
        [Route("/api/v1/item/search-by-total-item")]
        public async Task<IActionResult> SearchByTotalItem([FromQuery] decimal totalItem)
        {
            try
            {
                var allItems = await _itemService.SearchByTotalItem(totalItem);

                if (allItems.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum item foi encontrado com o valor total informado.",
                        Success = true,
                        Data = allItems
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Item(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allItems
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
