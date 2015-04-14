using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace Businesslayer
{
    public class Login
    {
    DbRemainder dbr = new DbRemainder();



        public bool CheckLogin(string email, string pass)
        {
            if (dbr.Checklogin(email, pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
