using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Validators;
using System;
using System.Collections.Generic;

namespace InvoiceApi.Domain.Entities
{
    public class Client : Base
    {
        //propriedades

        public string FirstName { get; private set; }        
        public string LastName { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual List<Contact> Contacts { get; private set; }
        public virtual List<Invoice> Invoices { get; private set; }

        //EF
        public Client()
        {

        }

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _errors = new List<string>();
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
            Validate();
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new ClientValidator();
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
