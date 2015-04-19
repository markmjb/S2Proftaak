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
            bool result = false;

            foreach (Event event2 in Events)
            {
                if (event2.Name == name && event2.Description == description && event2.StartDate == startDate && event2.EndDate == endDate && event2.TicketPrice == ticketPrice)
                {
                    result = true;
                }
            }

            return result;
        }
        public bool CheckEvent(int eventID)
        {
            bool result = false;

            foreach (Event event2 in Events)
            {
                if (event2.EventID == eventID)
                {
                    result = true;
                }
            }

            return result;
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
            DbEvent.CreateEvent(name, description, startDate, endDate, ticketPrice, addressID);
        }

        public Event GetEvent(string eventName, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            Event ev = null;

            foreach (Event event2 in Events)
            {
                if (event2.Name == eventName && event2.Description == description && event2.StartDate == startDate && event2.EndDate == endDate && event2.TicketPrice == ticketPrice)
                {
                    ev = event2;
                }
            }

            return ev;
        }

        public Event GetEvent(int eventID)
        {
            Event result = null;

            foreach (Event ev in Events)
            {
                if (ev.EventID == eventID)
                {
                    result = ev;
                }
            }
            return result;
        }

        public void DeleteEvent(int eventID)
        {
            DbEvent.DeleteEvent(eventID);
        }

        public void EditEvent(int eventID, string columnName, string columnValue)
        {
            DbEvent.EditEvent(eventID, columnName, columnValue);
        }
        public void EditEvent(int eventID, string columnName, decimal columnValue)
        {
            DbEvent.EditEvent(eventID, columnName, columnValue);
        }

    }
}
