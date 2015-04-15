using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class AddressDL
    {
        //FIELDS
        public int AddressID { get; set; }
        public string Street { get; set; }
        public int Streetnumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        
        //CONSTRUCTORS
        public AddressDL(string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            Street = street;
            Streetnumber = streetnumber;
            PostalCode = postalCode;
            City = city;
            Province = province;
            Country = country;
        }

        public AddressDL(int addressID, string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            AddressID = addressID;
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
