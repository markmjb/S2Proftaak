using System;
using System.Collections.Generic;

namespace Businesslayer.Business
{
    public class ReservationCampspot : Reservation
    {
        public List<int> Campingspots { get; set; }
        public decimal Price { get; set; }
        public List<User> ReservationUsers { get; set; }

        public ReservationCampspot(DateTime beginTime, DateTime endtime, User employee, List<int> campingspots, decimal price, List<User> reservationUsers) : base(beginTime, endtime, employee)
        {
            Campingspots = campingspots;
            Price = price;
            ReservationUsers = reservationUsers;
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
        public void UpdateCampingSpots()
        {
            
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
