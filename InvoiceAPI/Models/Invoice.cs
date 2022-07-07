using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Invoice
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }        
        public Client Client { get; set; }
        [Required(ErrorMessage = "Campo ClientId é obrigatório")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Campo SerialNumber é obrigatório")]
        public int SerialNumber { get; set; }
        [Required(ErrorMessage = "Campo Number é obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Campo Total é obrigatório")]
        public decimal Total { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Item> Items { get; set; }
    }
}
