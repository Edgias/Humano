﻿namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Address
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string? State { get; private set; }

        public string? Country { get; private set; }

        public Address(string street, string city, string? state, string? country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }
    }
}
