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
            Events = new List<Event>();
            GetEvents();
        }

        //METHODS
        public void GetEvents()
        {
            Events.Clear();

            Events = dbRemainder.GetEvents();
        }
    }
}
