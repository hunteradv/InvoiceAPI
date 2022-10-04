using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Enums;
using InvoiceApi.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceApi.Domain.Entities
{
    public class Invoice : Base
    {
        public virtual Client Client { get; private set; }        
        public long ClientId { get; private set; }        
        public int SerialNumber { get; private set; }        
        public int Number { get; private set; }
        public InvoiceStatus Status { get; private set; }
        public decimal Total { get; private set; }       
        public virtual List<Payment> Payments { get; private set; }
        public virtual List<Item> Items { get; private set; }

        //EF
        public Invoice()
        {

        }

        public Invoice(int clientId, int serialNumber, int number, InvoiceStatus status, decimal total)
        {
            ClientId = clientId;
            SerialNumber = serialNumber;
            Number = number;
            Status = status;
            Total = total;
        }

        public override bool Validate()
        {
            var validator = new InvoiceValidator();
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
