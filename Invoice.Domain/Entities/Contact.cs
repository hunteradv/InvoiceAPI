using FluentValidation;
using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Enums;
using InvoiceApi.Domain.Validators;
using System;

namespace InvoiceApi.Domain.Entities
{
    public class Contact : Base
    {
        public string ContactInfo { get; private set; }        
        public ContactType ContactType { get; private set; }        
        public virtual Client Client { get; private set; }        
        public long ClientId { get; private set; }

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
            var validator = new ContactValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
                }
            }

            return true;
        }
    }
}