using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class Event
    {
        //FIELDS
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TicketPrice { get; set; }
        public Address Address { get; set; }
        
        //CONSTRUCTORS
        public Event(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, Address address, string street, int streetnumber, string postalcode, string city, string state, string country)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TicketPrice = ticketPrice;

            Address = new Address(street, streetnumber, postalcode, city, state, country);
        }
    }
}
