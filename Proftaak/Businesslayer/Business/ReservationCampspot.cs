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
        private DbEvent dbrem = new DbEvent();

        public ReservationCampspot(DateTime beginTime, DateTime endtime, User employee, List<int> campingspots, decimal price, List<User> reservationUsers) : base(beginTime, endtime, employee)
        {
            Campingspots = campingspots;
            Price = price;
            ReservationUsers = reservationUsers;
        }

        public List<Event> Events()
        {
         return   dbrem.GetEvents();
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
        public List<int> UpdateCampingSpots()
        {
            return dbres.Campspots();
        }
        public void CheckorCreateGroup()
        {
            
        }
        public void HandlePayment()
        {
            
        }
        public void SaveReservation()
        {
            
        }
    }
}
