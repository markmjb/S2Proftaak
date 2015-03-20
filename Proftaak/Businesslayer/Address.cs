﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class Address
    {
        public string Street { get; set; }
        public int Streetnumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string street, int streetnumber, string postalCode, string city, string state, string country)
        {
            Street = street;
            Streetnumber = streetnumber;
            PostalCode = postalCode;
            City = city;
            State = state;
            Country = country;
        }
    }
}
