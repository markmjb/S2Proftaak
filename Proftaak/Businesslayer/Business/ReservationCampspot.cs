using System;
using System.Collections.Generic;
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
        public void AddToGroup()
        {
            
        }
        public void AddUser()
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
        public void HandlePayment()
        {
            
        }
        public void SaveReservation()
        {
            
        }

        public List<Group> GetAllGroups()
        {
           return dbres.GetAllGroups();
        }

        public void CreateGroup(string text)
        {
            dbres.Creategroup(text);
        }
    }
}
