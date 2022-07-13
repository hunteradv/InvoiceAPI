using AutoMapper;
using InvoiceAPI.Data;
using InvoiceAPI.Data.Dtos.Clients;
using InvoiceAPI.Models;
using InvoiceAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace InvoiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;

        public ClientController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddClient([FromBody] CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);

            _context.Add(client);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClientById), new { client.Id }, client);
        }

        [HttpGet]
        public IEnumerable GetClients()
        {
            return _context.Clients;
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();

            if (client is null)
            {
                return NotFound();
            }
            else
            {
                var dto = _mapper.Map<ReadClientDto>(client);
                return Ok(dto);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] UpdateClientDto dto)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();

            if (client is null)
            {
                return NotFound();
            }
            else
            {
                var clientDto = _mapper.Map(dto, client);
                _context.SaveChanges();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClient(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();

            if (client is null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(client);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
