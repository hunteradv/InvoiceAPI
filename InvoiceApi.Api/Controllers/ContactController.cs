using InvoiceApi.Api.ViewModels;
using InvoiceApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InvoiceApi.Api.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        [Route("/api/v1/contact/create")]
        public async Task<IActionResult> Create([FromBody] CreateContactViewModel contactViewModel)
        {
            try
            {
                return Ok();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
