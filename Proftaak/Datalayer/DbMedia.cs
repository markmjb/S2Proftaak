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

       public void AddMediaItem(String Type, String Title, String Description, String Category, int UserID)
       {
           try
           {
               CMD().CommandText =
                   " INSERT INTO PTS2_MEDIAITEM(Title,Type,Description,Category,UserID) VALUES (:title, :type, :desc, :cat, :uid)";
               CMD().Parameters.Add("title", Title);
               CMD().Parameters.Add("type", Type);
               CMD().Parameters.Add("desc", Description);
               CMD().Parameters.Add("cat", Category);
               CMD().Parameters.Add("uid", UserID);
               Openconnection();
               
               CMD().ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               Closeconnection();
           }
       }

       private void GetCategoryID(string categoryinput)
       {
           try
           {
               
               Openconnection();

               CMD().ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               Closeconnection();
           }

          

       }
 
    }
}
