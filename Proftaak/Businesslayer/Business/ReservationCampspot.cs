using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class ReservationCampspot : Reservation
    {
        public List<int> Campingspots { get; set; }
        public decimal Price { get; set; }
        public List<User> ReservationUsers { get; set; }

        private DbReservation dbres = new DbReservation();
        private DbEvent dbEvent = new DbEvent();

        public ReservationCampspot(DateTime beginTime, DateTime endtime, User employee, List<int> campingspots, decimal price, List<User> reservationUsers) : base(beginTime, endtime, employee)
        {
            Campingspots = campingspots;
            Price = price;
            ReservationUsers = reservationUsers;
        }

        public List<Event> Events()
        {
         return   dbEvent.GetEvents();
        }
        public ReservationCampspot()
        {
            
        }
        public List<Campspot> UpdateCampingSpots(int evid)
        {
            return dbres.Campspots(evid);
        }
        public List<Campspot> FilterCampingSpots(int evid, string filter)
        {
            return dbres.FilterCampspots(evid,filter);
        }
        public bool CheckGroup(string text)
        {
            return dbres.Groupexists(text);
        }
        public List<Group> GetAllGroups()
        {
           return dbres.GetAllGroups();
        }

        public void CreateGroup(string text)
        {
            dbres.Creategroup(text);
        }

        public void SaveReservation(IList<User> users, IList<Campspot> selectedcampspots, Event _event)
        {
            decimal price = selectedcampspots.Sum(c => c.Price);
            double days = (_event.EndDate - _event.StartDate).TotalDays;
            int fulldays = (int)(days += 0.5);
            decimal totalprice = price*fulldays;
            int Resid = dbres.SelectMaxID();
            Resid++;
            dbres.Insertreservation(_event, totalprice);
            foreach (Campspot c in selectedcampspots)
            {
                dbres.Insertreservation2(Resid, c.CampspotId);
            }

            foreach (User u in users)
            {
                dbres.insertAddress(u.Address);
                u.Address.AddressID = dbres.GetAddressID();
                dbres.InsertUser(u);
                u.ID = dbres.GetUserID();
                dbres.Insertreservation3(u.ID,Resid);
            }
        }
    }
}
