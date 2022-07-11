using InvoiceAPI.Models;

namespace InvoiceAPI.Data.Dtos.Clients
{
    public class UpdateClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
