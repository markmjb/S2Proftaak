using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace Businesslayer
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

        public List<ReservationAcces> GetAllReservations(int EventID)
        {
            List<ReservationAcces> ReservationBL = new List<ReservationAcces>();
            List<ReservationAccesDL> ReservationDL = DA.AllReservations(EventID);

            foreach(ReservationAccesDL R in ReservationDL)
            {
                ReservationBL.Add(new ReservationAcces(R.ReservationNr, R.Payment ));
            }
            return ReservationBL;
        }

        public List<User> GetUserInfo(int ResNr)
        {
            List<User> ReservationUsers = new List<User>();
            List<UserDL> ReservationUsersDL = DA.ReservationUser(ResNr);

            foreach (UserDL R in ReservationUsersDL)
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
