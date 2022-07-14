using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entities
{
    public class Address : Base
    {
        public int Number { get; private set; }        
        public string District { get; private set; }        
        public string City { get; private set; }        
        public string State { get; private set; }        
        public string Country { get; private set; }
        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }

        //EF
        protected Address(){}

        public Address(int number, string district, string city, string state, string country, Client client, int clientId)
        {
            Number = number;
            District = district;
            City = city;
            State = state;
            Country = country;
            Client = client;
            ClientId = clientId;
            _errors = new List<string>();
        }

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

        public override bool Validate()
        {
            return true;
        }
    }
}
