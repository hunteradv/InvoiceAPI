using InvoiceApi.Domain.Entities;
using InvoiceApi.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Api.ViewModels
{
    public class CreateInvoiceViewModel
    {
        [Required(ErrorMessage = "O id do cliente não deve ser nulo")]
        public long ClientId { get; set; }

        [Required(ErrorMessage = "O número de série não deve ser nulo")]
        public int SerialNumber { get; set; }

        [Required(ErrorMessage = "O número não deve ser nulo")]
        public int Number { get; set; }

        [Required(ErrorMessage = "O status não deve ser nulo")]
        public InvoiceStatus Status { get; set; }

        [Required(ErrorMessage = "O valor total da nota não deve ser nulo")]
        public decimal Total { get; set; }       
    }
}
