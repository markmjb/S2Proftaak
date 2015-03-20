using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    class ReservationCampspot
    {
        public User Employee { get; set; }
        public List<int> Campingspots { get; set; }
        public decimal Price { get; set; }
        public List<User> ReservationUsers { get; set; }

        public ReservationCampspot(User employee, List<int> campingspots, decimal price, List<User> reservationUsers)
        {
            Employee = employee;
            Campingspots = campingspots;
            Price = price;
            ReservationUsers = reservationUsers;
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
