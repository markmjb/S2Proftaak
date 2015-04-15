using Businesslayer.DAL;

namespace Businesslayer.Business
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
