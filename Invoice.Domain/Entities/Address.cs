using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Address : Base
    {
        public int Number { get; private set; }        
        public string District { get; private set; }        
        public string City { get; private set; }        
        public string State { get; private set; }        
        public string Country { get; private set; }
        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }
    }
}
