using InvoiceApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class CreateItemViewModel
    {
        [Required(ErrorMessage = "Quantidade é obrigatória")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Id da nota fiscal é obrigatório")]
        public long InvoiceId { get; set; }

        [Required(ErrorMessage = "Id do produto é obrigatório")]
        public long ProductId { get; set; }
    }
}
