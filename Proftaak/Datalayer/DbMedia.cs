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
        Databaseconnection dbc = new Databaseconnection();
        int MediacategoryID;

       public void AddMediaItem(String Title, String Description, int UserID)
       {
           try
           {
               Openconnection();
               CMD().CommandText =
                   " INSERT INTO PTS2_MEDIAITEM(Title,Type,Description,Category,UserID) VALUES (:title, :type, :desc, :cat, :uid)";
               CMD().Parameters.Add("title", Title);
               CMD().Parameters.Add("desc", Description);
               CMD().Parameters.Add("uid", UserID);
              
               
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

       public int GetCategoryID(string categoryinput)
       {
           try
           {
               Openconnection();
               CMD().CommandText = "SELECT MEDIACATEGORY FROM PTS2_MEDIACATEGORY WHERE MEDIACATEGORYNAME  = :input";
               CMD().Parameters.Add("input", categoryinput);

               OracleDataReader reader = CMD().ExecuteReader();

               while (reader.Read())
               {

                   MediacategoryID = Convert.ToInt32(reader["MEDIACATEGORYID"]);

               }
             

           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
            finally
            {
                Closeconnection();

              
            }
          
           return MediacategoryID;
       }
 
    }
}
