using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Client
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Primeiro FirstName é obrigatório")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Campo LastName é obrigatório")]
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
