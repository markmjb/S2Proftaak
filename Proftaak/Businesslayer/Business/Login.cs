using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class Login
    {
        private DbUserlogin dbul = new DbUserlogin();



        public bool CheckLogin(string email, string pass)
        {
            if (dbul.Checklogin(email, pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Changepass(string newpass)
        {
            dbul.Changepass(3, newpass);
            ;
        }

        public void Updateuser(string email, string pass)
        {
            Userlogin.Loggeduser = dbul.Getloggeduser(email, pass);
        }
    }
}
