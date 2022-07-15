using Invoice.Domain.Enums;

namespace Invoice.Domain.Entities
{
    public class Contact : Base
    {
        public string ContactInfo { get; private set; }        
        public ContactType ContactType { get; private set; }        
        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }

        public Contact(string contactInfo, ContactType contactType, int clientId)
        {
            ContactInfo = contactInfo;
            ContactType = contactType;
            ClientId = clientId;
        }

        
    }
}