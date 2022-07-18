using Invoice.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Address : Base
    {
        //propriedades
        public int Number { get; private set; }        
        public string District { get; private set; }        
        public string City { get; private set; }        
        public string State { get; private set; }        
        public string Country { get; private set; }
        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }

        //EF
        protected Address(){}

        public Address(int number, string district, string city, string state, string country, int clientId)
        {
            Number = number;
            District = district;
            City = city;
            State = state;
            Country = country;
            ClientId = clientId;
            _errors = new List<string>();
        }

        //comportamentos
        public void ChangeNumber(int number)
        {
            Number = number;
            Validate();
        }

        public void ChangeDistrict(string district)
        {
            District = district;
            Validate();
        }

        public void ChangeCity(string city)
        {
            City = city;
            Validate();
        }

        public void ChangeState(string state)
        {
            State = state;
            Validate();
        }

        public void ChangeCountry(string country)
        {
            Country = country;
            Validate();
        }

        public void ChangeClientId(int clientId)
        {
            ClientId = clientId;
            Validate();
        }

        //autovalida
        public override bool Validate()
        {
            var validator = new AddressValidator();
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
