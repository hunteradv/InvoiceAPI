using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "O nome do produto não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O nome do produto deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome do produto deve ter no máximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O valor unitário não deve ser nulo")]
        public decimal UnitValue { get; set; }
    }
}
