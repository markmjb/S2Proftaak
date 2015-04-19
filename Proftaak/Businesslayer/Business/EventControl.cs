using System;
using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class EventControl : Reservation
    {
        //FIELDS
        public List<Event> Events { get; set; }
        public DbEvent DbEvent { get; set; }

        //CONSTRUCTORS
        public EventControl()
        {
            DbEvent = new DbEvent();

            Events = new List<Event>();
            GetEvents();
        }

        //METHODS
        public void GetEvents()
        {
            Events.Clear();

            Events = DbEvent.GetEvents();
        }

        public bool CheckEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            return DbEvent.CheckEvent(name, description, startDate, endDate, ticketPrice);
        }

        public bool CheckAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            return DbEvent.CheckAddress(country, province, city, street, streetnumber, postalcode);
        }

        public void CreateAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            DbEvent.CreateAddress(country, province, city, street, streetnumber, postalcode);
        }

        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, int addressID)
        {
            DbEvent.CreateEvent(name, description, startDate, Endtime, ticketPrice, addressID);
        }

        public int GetEventID(string eventName, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            return DbEvent.GetEventID(eventName, description, startDate, Endtime, ticketPrice);
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
            DbEvent.DeleteEvent(eventID);
        }
    }
}
