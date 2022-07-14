namespace Invoice.Domain.Entities
{
    public class Contact : Base
    {        
        public string ContactInfo { get; set; }        
        public ContactType ContactType { get; set; }        
        public virtual Client Client { get; set; }        
        public int ClientId { get; set; }
    }
}