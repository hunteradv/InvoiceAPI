using InvoiceAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceAPI.Models
{
    public class Contact
    {
        [Key]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo ContactInfo é obrigatório")]
        public string ContactInfo { get; set; }
        [Required(ErrorMessage = "Campo ContactType é obrigatório")]
        public ContactType ContactType { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
        [Required(ErrorMessage = "Campo ClientId é obrigatório")]
        public int ClientId { get; set; }
    }
}