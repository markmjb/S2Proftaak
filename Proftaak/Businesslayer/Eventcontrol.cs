using System;
using Datalayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class EventControl : Reservation
    {
        //FIELDS
        public List<Event> Events { get; set; }
        private Datalayer.DbRemainder dbRemainder = new Datalayer.DbRemainder();

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
