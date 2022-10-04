using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class UpdateClientViewModel
    {
        [Required(ErrorMessage = "O id não pode ser vazio")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O primeiro nome não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O primeiro nome deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O primeiro nome deve ter no máximo 3 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O sobrenome não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O sobrenome deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O sobrenome deve ter no máximo 3 caracteres")]
        public string LastName { get; set; }
    }
}
