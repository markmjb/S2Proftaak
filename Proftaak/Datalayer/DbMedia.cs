using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class DbMedia : Databaseconnection
    {
       public void AddMediaItem(String Type, String Title, String Description, String Category, int UserID)
        {
            string sql = "INSERT INTO ";
        }
    }
}
