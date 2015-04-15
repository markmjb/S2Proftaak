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
            DA.DeleteRes(DL);
            DA.DeleteUserRes(DL);
        }

        public List<ReservationAccess> GetAllReservations(int EventID)
        {
            List<ReservationAccess> ReservationBL = new List<ReservationAccess>();
            List<ReservationAccess> ReservationDL = DA.AllReservations(EventID);

            foreach(ReservationAccess R in ReservationDL)
            {
                ReservationBL.Add(new ReservationAccess(R.ReservationNr, R.Payment ));
            }
            return ReservationBL;
        }

        public List<User> GetUserInfo(int ResNr)
        {
            List<User> ReservationUsers = new List<User>();
            List<User> ReservationUsersDL = DA.ReservationUser(ResNr);

            foreach (User R in ReservationUsersDL)
            {
                Group Group = new Group(R.Group.Name);
                Address Address = new Address(R.Address.Street, R.Address.Streetnumber, R.Address.PostalCode, R.Address.City, R.Address.Province, R.Address.Country);
                ReservationUsers.Add(new User(R.ReservationID, R.ID, R.Lastname, R.Firstname, R.Email, R.Password, R.Isadmin, R.StartDate, R.EndDate, Address, Group));
            }
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
