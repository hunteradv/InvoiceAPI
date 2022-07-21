using InvoiceApi.Domain.Enums;
using InvoiceApi.Domain.Validators;
using System;
using System.Collections.Generic;

namespace InvoiceApi.Domain.Entities
{
    public class Invoice : Base
    {

        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }        
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

        public Invoice(int clientId, int serialNumber, int number, decimal total, InvoiceStatus status)
        {
            ClientId = clientId;
            SerialNumber = serialNumber;
            Number = number;
            Total = total;
            Status = status;
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

                    throw new Exception("Alguns campos estão inválidos, por favor corrija-os!" + _errors[0]);
                }
            }

            return true;
        }
    }
}
