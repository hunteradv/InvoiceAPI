using InvoiceApi.Core.Exceptions;
using InvoiceApi.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Domain.Entities
{
    public class Product : Base
    {

        public string Name { get; private set; }       
        public decimal UnitValue { get; private set; }
        public virtual List<Item> Items { get; private set; }

        public Product()
        {

        }

        public Product(string name, decimal unitValue)
        {
            Name = name;
            UnitValue = unitValue;
        }

        public override bool Validate()
        {
            var validator = new ProductValidate();
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
