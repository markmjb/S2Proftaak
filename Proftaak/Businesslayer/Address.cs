using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Streetnumber { get; set; }
        public string PostalCode { get; set; }

        public Address(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            Country = country;
            Province = province;
            City = city;
            Street = street;
            Streetnumber = streetnumber;
            PostalCode = postalcode;
        }
    }
}
