using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbMedia 
    {      
        Mediaitem dalMediaitem= new Mediaitem();
        private int Returnint;
        List<Mediaitem> mediaitems = new List<Mediaitem>();
        private Databaseconnection db;

        public DbMedia()
        {
         db = new Databaseconnection();
        }

       public void AddMediaItem(String Title, String Description, int UserID)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText= " INSERT INTO PTS2_MEDIAITEM(Title,Description,UserID) VALUES (:title, :descr, :userid)";
               cmd.Parameters.Add("title", Title);
               cmd.Parameters.Add("descr", Description);
               cmd.Parameters.Add("userid", UserID);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }

        public void AddMediaItemFile(int MediaitemID, String Filelocation, int Filesize, String Filetype, int mediacategoryid)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = " INSERT INTO PTS2_MEDIAITEMFILE(mediaitemID,Filelocation, Filesize, Filetype,Mediacategoryid) VALUES (:mediaitemID ,:flocation, :fsize, :ftype, :mediacategoryid)";
               cmd.Parameters.Add("mediaitemID", MediaitemID);
               cmd.Parameters.Add("flocation", Filelocation);
               cmd.Parameters.Add("fsize", Filesize);
               cmd.Parameters.Add("ftype", Filetype );
               cmd.Parameters.Add("mediacateogryid", mediacategoryid);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }

        public int GetMediaItemID(string Title)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT MEDIAITEMID FROM PTS2_MEDIAITEM WHERE TITLE  = :Title";
                cmd.Parameters.Add("Title", Title);
                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                Returnint = Convert.ToInt32(reader["MEDIAITEMID"]);
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
            this.db.Connection.Close();
            }
        return Returnint;
        }

       public int GetCategoryID(string categoryinput)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT MEDIACATEGORY FROM PTS2_MEDIACATEGORY WHERE MEDIACATEGORYNAME  = :input";
               cmd.Parameters.Add("input", categoryinput);
               OracleDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
               Returnint = Convert.ToInt32(reader["MEDIACATEGORYID"]);
               }
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
            finally
           {
           this.db.Connection.Close();
           }
       return Returnint;
       }
        
       public List<Mediaitem>Getmediaitems()
       {
          try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM";
               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
                   dalMediaitem.Title = Convert.ToString(reader["TITLE"]);
                   dalMediaitem.Description = Convert.ToString(reader["DESCRIPTION"]);
                   dalMediaitem.UserID = Convert.ToInt32(reader["USERID"]);
                   mediaitems.Add(dalMediaitem);
               }
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
           this.db.Connection.Close();
           }
       return mediaitems;
       }

       public void RemoveMediaItem(Mediaitem mediaitem)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MEDIAITEM WHERE MEDIAITEMID = :MediaitemID";
               cmd.Parameters.Add("MediaitemID", mediaitem.Mediaitemid);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }

       public void RemoveMediaItemFile(Mediaitem mediaitem)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MEDIAITEMFILE WHERE MEDIAITEMID = :MediaitemID";
               cmd.Parameters.Add("MediaitemID", mediaitem.Mediaitemid);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }

       public Mediaitem Getsinglemediaitem(int mediaitemid)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM WHERE Mediaitemid = :Mediaitemid";
               cmd.Parameters.Add("Mediaitemid", mediaitemid);
               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
               dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
               dalMediaitem.Title = Convert.ToString(reader["TITLE"]);
               dalMediaitem.Description = Convert.ToString(reader["DESCRIPTION"]);
               dalMediaitem.UserID = Convert.ToInt32(reader["USERID"]);
               }
            }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
           this.db.Connection.Close();
           }
           return dalMediaitem;
       }
       public Mediaitem Getsinglemediaitemfile(int mediaitemid)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEMFILE WHERE Mediaitemid = :Mediaitemid";
               cmd.Parameters.Add("Mediaitemid", mediaitemid);
               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
               dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
               dalMediaitem.Filepath = Convert.ToString(reader["FILELOCATION"]);
               dalMediaitem.Filesize = Convert.ToInt32(reader["FILESIZE"]);
               dalMediaitem.Filetype = Convert.ToString(reader["FILETYPE"]);
               dalMediaitem.Mediacategoryofid=Convert.ToInt32(reader["MEDIACATEGORYID"]);
               }
           }
           catch (OracleException exc)
           {
           Console.WriteLine(exc);
           }
           finally
           {
           this.db.Connection.Close();
           }

       return dalMediaitem;
       }
        
       public List<Mediaitem> Getmediatext(int mediaitemid)
       {
            try
            {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEMTEXT WHERE Mediaitemcommentid = :Mediaitemid";
               cmd.Parameters.Add("Mediaitemid", mediaitemid);
               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
                dalMediaitem.Text = Convert.ToString(reader["TEXT"]);
                dalMediaitem.MediaitemcommentID= Convert.ToInt32(reader["MEDIAITEMCOMMENTID"]);
                mediaitems.Add(dalMediaitem);
               }
            }
           catch (OracleException exc)
           {
           Console.WriteLine(exc);
           }
           finally
           {
           this.db.Connection.Close();
           }
           return mediaitems;
       }
      
    }
}
