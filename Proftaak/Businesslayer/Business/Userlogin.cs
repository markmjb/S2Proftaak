using System;
using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
public static class Userlogin
{
    private static DbRemainder dbr= new DbRemainder();
    private static List<string> Objects = new List<string>();
    public static User Loggeduser;
    public static Address LoggeduserAddress;
    public static int uid = 1;
    public static void UpdateUser(string emailaddress,string password)
    {  
      Objects= dbr.Getloggeduser(emailaddress,password);
        LoggeduserAddress = new Address(Objects[4],Convert.ToInt32(Objects[5]), Objects[6], Objects[7],Objects[8],Objects[9]);
        Loggeduser = new User(Objects[1], Objects[2], LoggeduserAddress, Objects[3], Convert.ToInt32(Objects[0]));
    }


}
}
