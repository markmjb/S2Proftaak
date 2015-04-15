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

        public void ChangePresence()
        {
            
        }

        public void UpdatePeoplePresent()
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

        public void Search()
        {
            
        }

        public void AcceptPay()
        {
            int USERID = Userlogin.Loggeduser.ID;
        }
    }
}
