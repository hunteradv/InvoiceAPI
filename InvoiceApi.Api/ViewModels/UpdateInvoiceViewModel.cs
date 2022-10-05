using InvoiceApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class UpdateInvoiceViewModel
    {
        [Required(ErrorMessage = "Id não pode ser vazio")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O id do cliente não deve ser nulo")]
        public long ClientId { get; set; }

        [Required(ErrorMessage = "O número de série não deve ser nulo")]
        public int SerialNumber { get; set; }

        [Required(ErrorMessage = "O número não deve ser nulo")]
        public int Number { get; set; }

        [Required(ErrorMessage = "O status não deve ser nulo")]
        public InvoiceStatus Status { get; set; }

        [Required(ErrorMessage = "O total não pode ser vazio")]
        public decimal Total { get; set; }
    }
}
