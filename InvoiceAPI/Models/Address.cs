using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class Address
    {
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Numero é obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Campo Bairro é obrigatório")]
        public string District { get; set; }
        [Required(ErrorMessage = "Campo Cidade é obrigatório")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo Estado é obrigatório")]
        public string State { get; set; }
        [Required(ErrorMessage = "Campo País é obrigatório")]
        public string Country { get; set; }
        public Client Client { get; set; }
    }
}
