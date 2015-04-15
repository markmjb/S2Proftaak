using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class AddressDL
    {
        public string Street { get; set; }
        public int Streetnumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        public AddressDL(string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            Street = street;
            Streetnumber = streetnumber;
            PostalCode = postalCode;
            City = city;
            Province = province;
            Country = country;
        }

        public AddressDL()
        {
            
        }
    }
}
