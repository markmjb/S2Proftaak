using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
    public class DbMedia : Databaseconnection
    {
        private OracleConnection conn;

            public void Databaseconnection()
        {
         
                string user = "system";
                string pw = "system";
                conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + "127.0.0.1/" + ";";
                conn = new OracleConnection(conn.ConnectionString);
        }

        

       public void AddMediaItem(String Type, String Title, String Description, String Category, int UserID)
        {
  
            string sql = "INSERT INTO PTS2_MEDIAITEM VALUES ('" + Type + "'," + Title + "," + Description + ","  + Category + "," + UserID + ")";
            OracleConnection command = new OracleConnection(sql , conn.ConnectionString);
       }
    }
}
