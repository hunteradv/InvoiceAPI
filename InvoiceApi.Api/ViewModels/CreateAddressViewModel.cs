using InvoiceApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class CreateAddressViewModel
    {
        [Required(ErrorMessage = "O número não deve ser nulo")]
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long ClientId { get; set; }
    }
}
