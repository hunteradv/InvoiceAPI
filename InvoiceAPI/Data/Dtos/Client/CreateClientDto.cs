using InvoiceAPI.Models;
using System.Collections.Generic;

namespace InvoiceAPI.Data.Dtos.Clients
{
    public class CreateClientDto
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }
    }
}
