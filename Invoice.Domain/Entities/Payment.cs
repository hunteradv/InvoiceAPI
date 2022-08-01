using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Domain.Entities
{
    public class Payment : Base
    {

        public string Description { get; private set; }        
        public decimal Value { get; private set; }        
        public string PaymentType { get; private set; }
        public virtual Invoice Invoice { get; private set; }        
        public long InvoiceId { get; private set; }

        public Payment()
        {

        }

        public Payment(string description, decimal value, string paymentType, int invoiceId)
        {
            Description = description;
            Value = value;
            PaymentType = paymentType;
            InvoiceId = invoiceId;
        }

        public override bool Validate()
        {
            var validator = new PaymentValidator();
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
