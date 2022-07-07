﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Item
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }        
        [Required(ErrorMessage = "Campo Description é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo UnitValue é obrigatório")]
        public decimal UnitValue { get; set; }
        [Required(ErrorMessage = "Campo Quantity é obrigatório")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Campo TotalItem é obrigatório")]
        public decimal TotalItem { get; set; }
        public Invoice Invoice { get; set; }
        [Required(ErrorMessage = "Campo InvoiceId é obrigatório")]
        public int InvoiceId { get; set; }
        public Product Product { get; set; }
        [Required(ErrorMessage = "Campo ProductId é obrigatório")]
        public int ProductId { get; set; }
    }
}
