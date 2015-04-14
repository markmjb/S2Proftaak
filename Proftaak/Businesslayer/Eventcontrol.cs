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
        /*
        public string Description { get; set; }
        public Address LocationAddress { get; set; }
        public string Name { get; set; }
        public string Rfid { get; set; }

        
        public EventControl(DateTime beginTime, DateTime endtime, User employee, string description, Address locationAddress, string name, string rfid) : base(beginTime, endtime, employee)
        {
            Description = description;
            LocationAddress = locationAddress;
            Name = name;
            RFID = rfid;
        }
         */

        //FIELDS
        public List<Event> Events { get; set; } 

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
