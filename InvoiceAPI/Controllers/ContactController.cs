using AutoMapper;
using InvoiceAPI.Data;
using InvoiceAPI.Data.Dtos.Contact;
using InvoiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace InvoiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        public Context _context;
        public IMapper _mapper;        

        public ContactController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] CreateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);

            _context.Add(contact);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetContactById), new { contact.Id }, contact);
        }

        [HttpGet]
        public IEnumerable GetContacts()
        {
            return _context.Contacts;
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

            if (contact is null)
            {
                return NotFound();
            }
            else
            {
                var contactDto = _mapper.Map<ReadContactDto>(contact);
                return Ok(contactDto);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] UpdateContactDto dto)
        {
            var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

            if (contact is null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(dto, contact);
                _context.SaveChanges();

                return NoContent();
            }
        }

        [HttpDelete]
        public IActionResult RemoveContact(int id)
        {
            var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

            if (contact is null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(contact);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
