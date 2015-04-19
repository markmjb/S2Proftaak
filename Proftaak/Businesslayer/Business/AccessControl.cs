using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class AccessControl
    {
        DbAccess DA = new DbAccess();
        DbEvent DR = new DbEvent();

        public void AttachRFID(int UserID, int EventID, string RFID)
        {
            DA.AttachRFID(UserID, EventID, RFID);
        }

        public void DettachRFID(int EventID, string RFID)
        {
            DA.DettachRFID(EventID, RFID);
        }

        public void DeleteReservation(int ResNr)
        {
            DA.DeleteUserRes(ResNr);
            DA.DeleteRes(ResNr);
        }

        public List<ReservationAccess> GetAllReservations(int EventID)
        {
            List<ReservationAccess> Reservations = DA.AllReservations(EventID);
            return Reservations;
        }

        public List<User> GetAllReservationUser(int ResNr)
        {
            List<User> ReservationUsers = DA.ReservationUser(ResNr);
            return ReservationUsers;
        }

        public List<ReservationAccess> Search(int EventID, int Search)
        {
            List<ReservationAccess> Reservations = DA.Search(EventID, Search);
            return Reservations;
        }

        public bool GetPresents(int UserID)
        {
            bool isPresent = DA.IsPresent(UserID);
            return isPresent;
        }

        public bool GetRFID(string RFID)
        {
            bool isAttached = DA.GetRFIDStatus(RFID);
            return isAttached;
        }

        public bool GetUserRFID (int UserID)
        {
            bool isAttached = DA.GetuserRFID(UserID);
            return isAttached;
        }

        public int UserRFID (string RFID)
        {
            int UserID = DA.UserRFID(RFID);
            return UserID;
        }

        public void AcceptPay(int ResNr, decimal Price)
        {
            DA.AcceptPayment(ResNr, Price);
        }

        public void AcceptDebt(int UserID, int EventID)
        {
            DA.AcceptDebt(UserID, EventID);
        }

        public List<Event> GetEvents()
        {
            List<Event> Events = DR.GetEvents();
            return Events;
        }

        public List<User> GetAllUsers(int EventID)
        {
            List<User> AllUsers = DA.AllUsers(EventID);
            return AllUsers;
        }

        public void UpdatePresents(int UserID, bool Present)
        {
            DA.UpdateisPresent(UserID, Present);
        }
    }
}
