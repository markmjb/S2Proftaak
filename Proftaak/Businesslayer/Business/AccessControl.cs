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

        public List<User> GetUserInfo(int ResNr)
        {
            List<User> ReservationUsers = DA.ReservationUser(ResNr);
            return ReservationUsers;
        }

        public List<ReservationAccess> Search(int EventID, int Search)
        {
            List<ReservationAccess> Reservations = DA.Search(EventID, Search);
            return Reservations;
        }

        public bool getPresents(int UserID)
        {
            bool isPresent = DA.IsPresent(UserID);
            return isPresent;
        }

        public bool getRFID(string RFID)
        {
            bool isAttached = DA.GetRFIDStatus(RFID);
            return isAttached;
        }

        public bool getUserRFID (int UserID)
        {
            bool isAttached = DA.GetuserRFID(UserID);
            return isAttached;
        }

        public int UserRFID (string RFID)
        {
            int UserID = DA.UserRFID(RFID);
            return UserID;
        }

        public void AcceptPay(int ResNr)
        {
            DA.AcceptPayment(ResNr);
        }

        public void AcceptDept(int UserID, int EventID)
        {
            DA.AcceptDept(UserID, EventID);
        }

        public List<Event> GetEvents()
        {
            List<Event> Events = DR.GetEvents();
            return Events;
        }

        public List<User> GetAllUsers(int EventID)
        {
            List<User> AllUsers = DA.AllPresentUsers(EventID);
            return AllUsers;
        }

        public void UpdatePresents(int UserID, int Present)
        {
            DA.UpdateisPresent(UserID, Present);
        }
    }
}
