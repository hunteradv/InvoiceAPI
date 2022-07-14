using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Client : Base
    {                
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
