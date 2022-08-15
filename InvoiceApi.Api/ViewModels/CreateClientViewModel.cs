using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class CreateClientViewModel
    {
        [Required(ErrorMessage = "O primeiro nome não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O primeiro nome deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O primeiro nome deve ter no máximo 3 caracteres")]
        public string FirstName { get; private set; }

        [Required(ErrorMessage = "O sobrenome não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O sobrenome deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O sobrenome deve ter no máximo 3 caracteres")]
        public string LastName { get; private set; }
    }
}
