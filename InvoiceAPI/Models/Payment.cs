using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Payment
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Description é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo Value é obrigatório")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Campo PaymentType é obrigatório")]
        public string PaymentType { get; set; }
        public virtual Invoice Invoice { get; set; }
        [Required(ErrorMessage = "Campo InvoiceId é obrigatório")]
        public int InvoiceId { get; set; }
    }
}
