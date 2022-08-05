using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Services.DTO
{
    public class AddressDTO
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long ClientId { get; set; }

        public AddressDTO()
        {}

        public AddressDTO(long id, int number, string district, string city, string state, string country, long clientId)
        {
            Id = id;
            Number = number;
            District = district;
            City = city;
            State = state;
            Country = country;
            ClientId = clientId;
        }
    }
}
