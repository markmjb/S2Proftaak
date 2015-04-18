using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class Login
    {
    DbUserlogin dbul = new DbUserlogin();



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

    }
}
