using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
