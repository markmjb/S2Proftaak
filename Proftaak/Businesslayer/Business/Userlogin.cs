using Businesslayer.DAL;

namespace Businesslayer.Business
{
public static class Userlogin
{
    private static DbUserlogin dbul = new DbUserlogin();
    public static User Loggeduser;
    public static void UpdateUser(string emailaddress,string password)
    {  
      Loggeduser = dbul.Getloggeduser(emailaddress,password);
    }

}
}
