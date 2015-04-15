using System;

namespace Businesslayer.Business
{
    public class Event
    {
        //FIELDS
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int UserID { get; set; }
        public Address Address { get; set; }
        
        //CONSTRUCTORS
        public Event(int eventID, string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, int userID, int addressID, string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            EventID = eventID;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TicketPrice = ticketPrice;
            UserID = userID;
            Address = new Address(addressID, street, streetnumber, postalCode, city, province, country);
        }
    }
}
