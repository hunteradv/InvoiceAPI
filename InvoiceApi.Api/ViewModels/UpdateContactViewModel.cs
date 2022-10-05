using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class UpdateContactViewModel
    {
        [Required(ErrorMessage = "Id não pode ser vazio")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O contato não pode ser nulo")]
        [MinLength(3, ErrorMessage = "O contato deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O contato deve ter no máximo 80 caracteres")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "O tipo do contato não pode ser nulo")]
        public int ContactType { get; set; }

        [Required(ErrorMessage = "O id do cliente não pode ser nulo")]
        public long ClientId { get; set; }
    }
}
