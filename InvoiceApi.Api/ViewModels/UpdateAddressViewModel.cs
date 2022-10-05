using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class UpdateAddressViewModel
    {
        [Required(ErrorMessage = "Id não pode ser vazio")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O número não deve ser nulo")]
        public int Number { get; set; }

        [Required(ErrorMessage = "O bairro não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O bairro deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O bairro deve ter no máximo 80 caracteres")]
        public string District { get; set; }

        [Required(ErrorMessage = "A cidade não deve ser nula")]
        [MinLength(3, ErrorMessage = "A cidade deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "A cidade deve ter no máximo 80 caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "O estado não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O estado deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O estado deve ter no máximo 80 caracteres")]
        public string State { get; set; }

        [Required(ErrorMessage = "O país não deve ser nulo")]
        [MinLength(3, ErrorMessage = "O país deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O país deve ter no máximo 80 caracteres")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O id do cliente não deve ser nulo")]
        public long ClientId { get; set; }
    }
}
