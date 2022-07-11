using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Address
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Number é obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Campo District é obrigatório")]
        public string District { get; set; }
        [Required(ErrorMessage = "Campo City é obrigatório")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo State é obrigatório")]
        public string State { get; set; }
        [Required(ErrorMessage = "Campo Country é obrigatório")]
        public string Country { get; set; }
        public Client Client { get; set; }
        [Required(ErrorMessage = "Campo ClientId é obrigatório")]
        public int ClientId { get; set; }
    }
}
