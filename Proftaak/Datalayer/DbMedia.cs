using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
    public class DbMedia 
    {      
        
        int MediacategoryID;
        private Databaseconnection db = new Databaseconnection();
        private OracleConnection dbmediaconn;

        public DbMedia()
        {
            dbmediaconn = new OracleConnection();
            dbmediaconn.ConnectionString = db.getstring();
        }

       public void AddMediaItem(String Title, String Description, int UserID)
       {
           try
           {
               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText= " INSERT INTO PTS2_MEDIAITEM(Title,Type,Description,Category,UserID) VALUES (:title, :type, :desc, :cat, :uid)";
               cmd.Parameters.Add("title", Title);
               cmd.Parameters.Add("desc", Description);
               cmd.Parameters.Add("uid", UserID);
              
               
               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.dbmediaconn.Close();
           }
       }

       public int GetCategoryID(string categoryinput)
       {
           try
           {
               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText = "SELECT MEDIACATEGORY FROM PTS2_MEDIACATEGORY WHERE MEDIACATEGORYNAME  = :input";
               cmd.Parameters.Add("input", categoryinput);

               OracleDataReader reader = cmd.ExecuteReader();

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
               this.dbmediaconn.Close();


           }
          
           return MediacategoryID;
       }
 
    }
}
