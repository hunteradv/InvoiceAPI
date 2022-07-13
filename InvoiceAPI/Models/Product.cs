using System.Collections.Generic;
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
        [Required(ErrorMessage = "Campo UnitValue é obrigatório")]
        public decimal UnitValue { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
