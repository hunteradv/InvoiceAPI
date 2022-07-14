using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Client : Base
    {                
        public string FirstName { get; private set; }        
        public string LastName { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual List<Contact> Contacts { get; private set; }
        public virtual List<Invoice> Invoices { get; private set; }
    }
}
