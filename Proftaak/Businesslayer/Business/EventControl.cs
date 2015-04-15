using System;
using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class EventControl : Reservation
    {
        //FIELDS
        public List<Event> Events { get; set; }
        private DbRemainder dbRemainder = new DbRemainder();

        //CONSTRUCTORS
        public EventControl()
        {
        }

        //METHODS
        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            Events.Add(new Event(name, description, startDate, endDate, ticketPrice, country, province, city, street, streetnumber, postalcode));
        }
    }
}
