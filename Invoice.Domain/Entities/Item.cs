using InvoiceApi.Domain.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Domain.Entities
{
    public class Item : Base
    {

        public string Description { get; private set; }        
        public decimal UnitValue { get; private set; }        
        public int Quantity { get; private set; }        
        public decimal TotalItem { get; private set; }
        public virtual Invoice Invoice { get; private set; }        
        public long InvoiceId { get; private set; }
        public virtual Product Product { get; private set; }        
        public long ProductId { get; private set; }

        //EF
        public Item()
        {

        }

        public Item(string description, decimal unitValue, int quantity, decimal totalItem, int invoiceId, int productId)
        {
            Description = description;
            UnitValue = unitValue;
            Quantity = quantity;
            TotalItem = totalItem;
            InvoiceId = invoiceId;
            ProductId = productId;
        }

        public override bool Validate()
        {
            var validator = new ItemValidator();
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
