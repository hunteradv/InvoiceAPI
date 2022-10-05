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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/product/create")]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel productViewModel)
        {
            try
            {
                var productDTO = _mapper.Map<ProductDTO>(productViewModel);
                var productCreated = await _productService.Create(productDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Produto criado com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch(DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplictationErrorMessage());
            }
        }

        [HttpPut]
        [Route("api/v1/product/update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductViewModel productViewModel)
        {
            try
            {
                var productDTO = _mapper.Map<ProductDTO>(productViewModel);
                var productUpdated = await _productService.Update(productDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Produto atualizado com sucesso!",
                    Success = true,
                    Data = productUpdated
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
        [Route("/api/v1/product/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _productService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Produto removido com sucesso!",
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
    }
}
