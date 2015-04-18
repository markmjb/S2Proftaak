namespace Businesslayer.Business
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public int Streetnumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        public Address(int addressID, string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            AddressID = addressID;
            Street = street;
            Streetnumber = streetnumber;
            PostalCode = postalCode;
            City = city;
            Province = province;
            Country = country;
        }
        public Address(string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            Street = street;
            Streetnumber = streetnumber;
            PostalCode = postalCode;
            City = city;
            Province = province;
            Country = country;
        }

        public Address()
        {
            
        }
    }
}
