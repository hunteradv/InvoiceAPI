using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class UpdateItemViewModel
    {
        [Required(ErrorMessage = "Id não pode ser vazio")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [MinLength(3, ErrorMessage = "Descrição deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "Descrição deve ter no máximo 80 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Id da nota fiscal é obrigatório")]
        public long InvoiceId { get; set; }

        [Required(ErrorMessage = "Id do produto é obrigatório")]
        public long ProductId { get; set; }
    }
}
