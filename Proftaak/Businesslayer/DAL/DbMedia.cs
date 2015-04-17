using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbMedia 
    {      
        
        
        int MediacategoryID;
        Mediaitem mediaitem;
        public int MediaitemID { get; set; }
        private Databaseconnection db;
        private OracleConnection dbmediaconn;
        

       

        public DbMedia()
        {
            dbmediaconn = new OracleConnection();
            db = new Databaseconnection();

            dbmediaconn.ConnectionString = db.getstring();
        }

       public void AddMediaItem(String Title, String Description, int UserID)
       {
           try
           {

               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText= " INSERT INTO PTS2_MEDIAITEM(Title,Description,UserID) VALUES (:title, :descr, :userid)";
               cmd.Parameters.Add("title", Title);
               cmd.Parameters.Add("descr", Description);
               cmd.Parameters.Add("userid", UserID);

               dbmediaconn.Open();
               
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

        public void AddMediaItemFile(int MediaitemID, String Filelocation, int Filesize, String Filetype, int mediacategoryid)
       {
           try
           {

               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText = " INSERT INTO PTS2_MEDIAITEMFILE(mediaitemID,Filelocation, Filesize, Filetype,Mediacategoryid) VALUES (:mediaitemID ,:flocation, :fsize, :ftype, :mediacategoryid)";
               cmd.Parameters.Add("mediaitemID", MediaitemID);
               cmd.Parameters.Add("flocation", Filelocation);
               cmd.Parameters.Add("fsize", Filesize);
               cmd.Parameters.Add("ftype", Filetype );
               cmd.Parameters.Add("mediacateogryid", mediacategoryid);

               dbmediaconn.Open();
               
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

        public int GetMediaItemID(string Title)
        {
            try
            {
                OracleCommand cmd = this.dbmediaconn.CreateCommand();
                cmd.CommandText = "SELECT MEDIAITEMID FROM PTS2_MEDIAITEM WHERE TITLE  = :Title";
                cmd.Parameters.Add("Title", Title);
                
                dbmediaconn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    MediaitemID = Convert.ToInt32(reader["MEDIAITEMID"]);

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

            return MediaitemID;
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


       public List<Mediaitem>Getmediaitems()
       {
           List<Mediaitem> mediaitems = new List<Mediaitem>();
           try
           {
               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM";
               dbmediaconn.Open();
               OracleDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {

                   int MediaitemID = Convert.ToInt32(reader["MEDIAITEMID"]);
                   string Title = Convert.ToString(reader["TITLE"]);
                   string Description = Convert.ToString(reader["DESCRIPTION"]);
                   int Userid = Convert.ToInt32(reader["USERID"]);

                   Mediaitem mediaitem = new Mediaitem(MediaitemID, Title, Description, Userid);
                   mediaitems.Add(mediaitem);



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

           return mediaitems;
       }

       public void RemoveMediaItem(Mediaitem mediaitem)
       {
           try
           {
               int MediaitemID = mediaitem.Mediaitemid;

               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MEDIAITEM WHERE MEDIAITEMID = :MediaitemID";
               cmd.Parameters.Add("MediaitemID", MediaitemID);
            

               dbmediaconn.Open();

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
       public Mediaitem Getsinglemediaitem(int mediaitemid)
       {
           
           try
           {
               
               OracleCommand cmd = this.dbmediaconn.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM WHERE Mediaitemid = :Mediaitemid";
               cmd.Parameters.Add("Mediaitemid", mediaitemid);
               dbmediaconn.Open();
               OracleDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {

                   int MediaitemID = Convert.ToInt32(reader["MEDIAITEMID"]);
                   string Title = Convert.ToString(reader["TITLE"]);
                   string Description = Convert.ToString(reader["DESCRIPTION"]);
                   int Userid = Convert.ToInt32(reader["USERID"]);

                   mediaitem = new Mediaitem(MediaitemID, Title, Description, Userid);
            



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

           return mediaitem;
       }

      
    }
}
