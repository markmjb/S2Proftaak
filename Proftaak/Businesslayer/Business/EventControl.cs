using System;
using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class EventControl : Reservation
    {
        //FIELDS
        public List<Event> Events { get; set; }
        public DbRemainder dbRemainder { get; set; }

        //CONSTRUCTORS
        public EventControl()
        {
            dbRemainder = new DbRemainder();

            Events = new List<Event>();
            GetEvents();
        }

        //METHODS
        public void GetEvents()
        {
            Events.Clear();

            Events = dbRemainder.GetEvents();
        }

        public bool CheckEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            return dbRemainder.CheckEvent(name, description, startDate, endDate, ticketPrice);
        }

        public bool CheckAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            return dbRemainder.CheckAddress(country, province, city, street, streetnumber, postalcode);
        }

        public void CreateAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            dbRemainder.CreateAddress(country, province, city, street, streetnumber, postalcode);
        }

        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, int addressID)
        {
            dbRemainder.CreateEvent(name, description, startDate, Endtime, ticketPrice, addressID);
        }

        public int GetEventID(string eventName, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            return dbRemainder.GetEventID(eventName, description, startDate, Endtime, ticketPrice);
        }

        public Event GetEvent(int eventID)
        {
            foreach (Event ev in Events)
            {
                if (ev.EventID == eventID)
                {
                    return ev;
                }
            }
            return null;
        }

        public void DeleteEvent(int eventID)
        {
            dbRemainder.DeleteEvent(eventID);
        }
    }
}
