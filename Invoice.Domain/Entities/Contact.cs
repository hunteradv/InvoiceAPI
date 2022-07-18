using Invoice.Domain.Enums;

namespace Invoice.Domain.Entities
{
    public class Contact : Base
    {
        public string ContactInfo { get; private set; }        
        public ContactType ContactType { get; private set; }        
        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }

        public Contact()
        {

        }

        public Contact(string contactInfo, ContactType contactType, int clientId)
        {
            ContactInfo = contactInfo;
            ContactType = contactType;
            ClientId = clientId;
        }

        public void ChangeContactInfo(string contactInfo)
        {
            ContactInfo = contactInfo;
        }

        public void ChangeContactType(ContactType contactType)
        {
            ContactType = contactType;
        }

        public void ChanceClientId(int clientId)
        {
            ClientId = clientId;
        }


        public override bool Validate()
        {
            return true;
        }
    }
}