using Businesslayer.DAL;

namespace Businesslayer.Business
{
public static class Userlogin
{
    private static DbRemainder dbr= new DbRemainder();
    public static User Loggeduser;
    public static void UpdateUser(string emailaddress,string password)
    {  
      Loggeduser = dbr.Getloggeduser(emailaddress,password);
    }

}
}
