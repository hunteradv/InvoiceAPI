using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Client
    {
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Primeiro Nome é obrigatório")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Campo Sobrenome é obrigatório")]
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
