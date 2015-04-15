using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class AccessControl
    {
        DbAccess DA = new DbAccess();

        public void AttachRfid()
        {
            
        }


        public void DeleteReservation(int DL)
        {
            DA.DeleteUserRes(DL);
            DA.DeleteRes(DL);
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

        public List<ReservationAccess> Search(int EventID, string Search)
        {
            List<ReservationAccess> Reservations = DA.Search(EventID, Search);
            return Reservations;
        }

        public bool getPresents(int UserID)
        {
            bool isPresent = DA.IsPresent(UserID);
            return isPresent;
        }

        public bool getRFID(int RFID)
        {
            bool isAttached = DA.GetRFIDStatus(RFID);
            return isAttached;
        }

        public void AcceptPay()
        {
            int USERID = Userlogin.Loggeduser.ID;
        }
    }
}
