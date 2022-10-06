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

        [HttpGet]
        [Route("/api/v1/product/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var product = await _productService.Get(id);

                if (product == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum produto foi encontrado com o Id informado",
                        Success = true,
                        Data = product
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Produto encontrado com sucesso!",
                    Success = true,
                    Data = product
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
        [Route("/api/v1/product/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allProducts = await _productService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Produtos encontrados com sucesso!",
                    Success = true,
                    Data = allProducts
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
        [Route("/api/v1/product/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allProducts = await _productService.SearchByName(name);

                if (allProducts.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum produto foi encontrado com o tipo informado.",
                        Success = true,
                        Data = allProducts
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Produto(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allProducts
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
        [Route("/api/v1/product/search-by-unit-value")]
        public async Task<IActionResult> SearchByUnitValue([FromQuery] decimal unitValue)
        {
            try
            {
                var allProducts = await _productService.SearchByUnitValue(unitValue);

                if (allProducts.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum produto foi encontrado com o tipo informado.",
                        Success = true,
                        Data = allProducts
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Produto(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = allProducts
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
