using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbMedia
    {
        private Mediaitem dalMediaitem;
        private int Returnint;
        private List<Mediaitem> mediaitems;
        private Databaseconnection db;
        int aantallikes;
        
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
            dalMediaitem = new Mediaitem();
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
          
           mediaitems = new List<Mediaitem>();
          try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM";
               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   dalMediaitem = new Mediaitem();
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
           dalMediaitem = new Mediaitem();
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
           dalMediaitem = new Mediaitem();
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
           dalMediaitem = new Mediaitem();
           mediaitems = new List<Mediaitem>();
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

       public int GetAllLikes(int mediaitemid)
       {
           aantallikes = 0;

           try
           {
              
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_LIKE WHERE MEDIAITEMID = :mediaitemid";
               cmd.Parameters.Add("MediaitemID", mediaitemid);
               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               cmd.ExecuteReader();

               while (reader.Read())
               {
                   int Likeid = Convert.ToInt32(reader["LIKEID"]);
                   int Userid = Convert.ToInt32(reader["USERID"]);
                   int Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);

                   if(Mediaitemid == mediaitemid)
                   {
                       aantallikes++;
                   }
                  
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
           return aantallikes;
           
       }

       public void AddLikeToFile(int mediaitemid, int userid)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = " INSERT INTO PTS2_Like(Userid, MediaitemID) VALUES (:userid, :mediaitemid)";


               cmd.Parameters.Add("Userid", userid);
               cmd.Parameters.Add("MediaitemID", mediaitemid);
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

        public void AddLikeToReply(int mediaitemid, int userid)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_Like(Userid, MediaitemID) VALUES (:userid, :mediaitemid) WHERE MEDIAITEMID LIKE (SELECT MEDIAITEMCOMMENTID FROM PTS2_MEDIAITEMTEXT WHERE MEDIAITEMCOMMENTID = :mediaitemid)";


               cmd.Parameters.Add("Userid", userid);
               cmd.Parameters.Add("mediaitemID", mediaitemid);
               
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

        public List<Mediaitem> AlreadyLiked()
        {
            dalMediaitem = new Mediaitem();
            mediaitems = new List<Mediaitem>();
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PTS2_LIKE";
                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dalMediaitem.Likeid = Convert.ToInt32(reader["MEDIAITEMID"]);
                    dalMediaitem.UserID = Convert.ToInt32(reader["USERID"]);
                    dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
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
        public void RemoveLikeToFile(int mediaitemid, int userid)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_Like WHERE MEDIAITEMID = :mediaitemid AND USERID = :userid";

                cmd.Parameters.Add("Userid", userid);
                cmd.Parameters.Add("mediaitemID", mediaitemid);

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

        public void RemoveLikeToReply(int mediaitemid, int userid)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_Like WHERE MEDIAITEMID = :mediaitemid AND USERID = :userid";

                cmd.Parameters.Add("Userid", userid);
                cmd.Parameters.Add("mediaitemID", mediaitemid);

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
        
    }
}
