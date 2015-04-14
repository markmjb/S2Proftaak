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

        public void GetAllReservations()
        {
            
        }

        public void GetUserInfo()
        {
            
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
