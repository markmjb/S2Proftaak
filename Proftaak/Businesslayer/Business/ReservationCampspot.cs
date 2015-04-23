using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class ReservationCampspot : Reservation
    {
        public IList<int> Campingspots { get; set; }
        public decimal Price { get; set; }
        public IList<User> ReservationUsers { get; set; }

        private DbReservation dbres = new DbReservation();
        private DbEvent dbEvent = new DbEvent();

        public ReservationCampspot(DateTime beginTime, DateTime endtime, User employee, IList<int> campingspots, decimal price, IList<User> reservationUsers) : base(beginTime, endtime, employee)
        {
            Campingspots = campingspots;
            Price = price;
            ReservationUsers = reservationUsers;
        }

        public IList<Event> Events()
        {
         return   dbEvent.GetEvents();
        }
        public ReservationCampspot()
        {
            
        }
        public IList<Campspot> UpdateCampingSpots(int evid)
        {
            return dbres.Campspots(evid);
        }
        public IList<Campspot> FilterCampingSpots(int evid, string filter)
        {
            return dbres.FilterCampspots(evid,filter);
        }
        public bool CheckGroup(string text)
        {
            return dbres.Groupexists(text);
        }
        public IList<Group> GetAllGroups()
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
            decimal priceperuser;
            priceperuser = totalprice/users.Count;
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
                u.ReservationID = dbres.GetReservationID();
                dbres.Insertreservation3(u.ID,Resid);
                dbres.UpdateDebt(u.ID,priceperuser,_event.EventID);
                
            }
        }
    }
}
