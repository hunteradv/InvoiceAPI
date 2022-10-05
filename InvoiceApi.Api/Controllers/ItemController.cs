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
    }
}
