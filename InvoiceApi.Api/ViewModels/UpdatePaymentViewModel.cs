using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class UpdatePaymentViewModel
    {
        [Required(ErrorMessage = "Id não pode ser vazio")]
        public long Id { get; set; }

        [Required(ErrorMessage = "A descrição não pode ser nula")]
        [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "A descrição deve ter no mínimo 80 cracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O valor não pode ser nula")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O tipo de pagamento não pode ser nula")]
        [MinLength(3, ErrorMessage = "O tipo de pagamento deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O tipo de pagamento deve ter no mínimo 80 cracteres")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "O id da nota fiscal não pode ser nula")]
        public long InvoiceId { get; set; }
    }
}
