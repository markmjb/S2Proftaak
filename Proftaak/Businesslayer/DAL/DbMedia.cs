using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace Businesslayer.DAL
{
    public class DbMedia
    {
        private Report dalReport;
        private Report dalSingleReport;
        private Mediaitem dalMediaitem;
        private int Returnint;
        private int UserID;
        private List<string> Categories;
        private List<Report> reports;
        private List<Mediaitem> mediaitems;
        private Databaseconnection db;
        string naam;
        int aantallikes;
        int categoryid;
        
        public DbMedia()
        {
         db = new Databaseconnection();
        }

       public void AddMediaItem(String Title, String Description, int UserID)
       {
           try
           {
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText= " INSERT INTO PTS2_MEDIAITEM(Title,Description,UserID) VALUES (:title, :descr, :userid)";
               cmd.Parameters.AddWithValue("title", Title);
               cmd.Parameters.AddWithValue("descr", Description);
               cmd.Parameters.AddWithValue("userid", UserID);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = " INSERT INTO PTS2_MEDIAITEMFILE(mediaitemID,Filelocation, Filesize, Filetype,Mediacategoryid) VALUES (:mediaitemID ,:flocation, :fsize, :ftype, :mediacategoryid)";
               cmd.Parameters.AddWithValue("mediaitemID", MediaitemID);
               cmd.Parameters.AddWithValue("flocation", Filelocation);
               cmd.Parameters.AddWithValue("fsize", Filesize);
               cmd.Parameters.AddWithValue("ftype", Filetype );
               cmd.Parameters.AddWithValue("mediacateogryid", mediacategoryid);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (Exception exc)
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
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT MEDIAITEMID FROM PTS2_MEDIAITEM WHERE TITLE  = :Title";
                cmd.Parameters.AddWithValue("Title", Title);
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                Returnint = Convert.ToInt32(reader["MEDIAITEMID"]);
                }
            }
            catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT MEDIACATEGORY FROM PTS2_MEDIACATEGORY WHERE MEDIACATEGORYNAME  = :input";
               cmd.Parameters.AddWithValue("input", categoryinput);
               OleDbDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
               Returnint = Convert.ToInt32(reader["MEDIACATEGORYID"]);
               }
           }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM";
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
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
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
           this.db.Connection.Close();
           }
       return mediaitems;
       }

       public List<Mediaitem> Getmediatext(int mediaitemid)
       {

           mediaitems = new List<Mediaitem>();
           try
           {
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEMTEXT WHERE MEDIAITEMCOMMENTID = :mediaitemid";
               cmd.Parameters.AddWithValue("MEDIAITEMID", mediaitemid);
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   dalMediaitem = new Mediaitem();
                   dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
                   dalMediaitem.Text = Convert.ToString(reader["TEXT"]);
                   dalMediaitem.MediaitemcommentID = Convert.ToInt32(reader["MEDIAITEMCOMMENTID"]);
                   dalMediaitem.UserID = Convert.ToInt32(reader["USERID"]);
                   mediaitems.Add(dalMediaitem);
               }
           }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MEDIAITEM WHERE MEDIAITEMID = :MediaitemID";
               cmd.Parameters.AddWithValue("MediaitemID", mediaitem.Mediaitemid);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MEDIAITEMFILE WHERE MEDIAITEMID = :MediaitemID";
               cmd.Parameters.AddWithValue("MediaitemID", mediaitem.Mediaitemid);
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM WHERE Mediaitemid = :Mediaitemid";
               cmd.Parameters.AddWithValue("Mediaitemid", mediaitemid);
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
               dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
               dalMediaitem.Title = Convert.ToString(reader["TITLE"]);
               dalMediaitem.Description = Convert.ToString(reader["DESCRIPTION"]);
               dalMediaitem.UserID = Convert.ToInt32(reader["USERID"]);
               }
            }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEMFILE WHERE Mediaitemid = :Mediaitemid";
               cmd.Parameters.AddWithValue("Mediaitemid", mediaitemid);
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
               dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
               dalMediaitem.Filepath = Convert.ToString(reader["FILELOCATION"]);
               dalMediaitem.Filesize = Convert.ToInt32(reader["FILESIZE"]);
               dalMediaitem.Filetype = Convert.ToString(reader["FILETYPE"]);
               dalMediaitem.Mediacategoryofid=Convert.ToInt32(reader["MEDIACATEGORYID"]);
               }
           }
           catch (Exception exc)
           {
           Console.WriteLine(exc);
           }
           finally
           {
           this.db.Connection.Close();
           }

       return dalMediaitem;
       }

       public int GetAllLikes(int mediaitemid)
       {
           aantallikes = 0;

           try
           {
              
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_LIKE WHERE MEDIAITEMID = :mediaitemid";
               cmd.Parameters.AddWithValue("MediaitemID", mediaitemid);
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
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
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
           return aantallikes;
           
       }
       public int GetAllLikesReply(int mediacategoryid)
       {
           aantallikes = 0;

           try
           {

               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT * FROM PTS2_LIKE WHERE MEDIACATEGORYID = :mediaitemid";
               cmd.Parameters.AddWithValue("MediacategoryID", mediacategoryid);
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
               cmd.ExecuteReader();

               while (reader.Read())
               {
                   int Likeid = Convert.ToInt32(reader["LIKEID"]);
                   int Userid = Convert.ToInt32(reader["USERID"]);
                   int Mediacategoryid = Convert.ToInt32(reader["MEDIACATEGORYID"]);

                   if (Mediacategoryid == mediacategoryid)
                   {
                       aantallikes++;
                   }

               }
           }
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
           return aantallikes;

       }

       public string PostedBy(int userid)
       {
      
           try
           {

               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT FIRSTNAME, LASTNAME FROM PTS2_USER WHERE USERID = :userid";
               cmd.Parameters.AddWithValue("USERID", userid);
               db.Connection.Open();
               OleDbDataReader reader = cmd.ExecuteReader();
               cmd.ExecuteReader();

               while (reader.Read())
               {
                   string voornaam = Convert.ToString(reader["FIRSTNAME"]);
                   string achternaam = Convert.ToString(reader["LASTNAME"]);

                   naam = voornaam + " " + achternaam;

               }
           }
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
           return naam;

       }
       public void AddLikeToFile(int mediaitemid, int userid)
       {
           try
           {
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = " INSERT INTO PTS2_Like(Userid, MediaitemID) VALUES (:userid, :mediaitemid)";


               cmd.Parameters.AddWithValue("Userid", userid);
               cmd.Parameters.AddWithValue("MediaitemID", mediaitemid);
               db.Connection.Open();
               cmd.ExecuteReader();

              
           }
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }

       public void AddReplytofile(string text, int mediaitemcommentid, int userid)
       {
           try
           {
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = " INSERT INTO PTS2_MEDIAITEMTEXT(Text,Mediaitemcommentid,userid) VALUES (:text, :mediaitemcommentid, :userid)";

               cmd.Parameters.AddWithValue("Text", text);
               cmd.Parameters.AddWithValue("Mediaitemcommentid", mediaitemcommentid);
               cmd.Parameters.AddWithValue("Userid", userid);

               db.Connection.Open();
               cmd.ExecuteReader();


           }
           catch (Exception exc)
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
               OleDbCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_Like(Userid, MediaCategoryID) VALUES (:userid, :mediaitemid) ";


               cmd.Parameters.AddWithValue("Userid", userid);
               cmd.Parameters.AddWithValue("mediaitemID", mediaitemid);
               
               db.Connection.Open();
               cmd.ExecuteReader();
           }
           catch (Exception exc)
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
           
            mediaitems = new List<Mediaitem>();
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PTS2_LIKE";
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     dalMediaitem = new Mediaitem();
                
                
                   

                    if (reader.IsDBNull(reader.GetOrdinal("LIKEID")))
                    {
                        dalMediaitem.Likeid = 0;
                    }
                    else
                    {
                        dalMediaitem.Likeid = Convert.ToInt32(reader["LIKEID"]);
                    
                    }
                    
                 
                    dalMediaitem.UserID = Convert.ToInt32(reader["USERID"]);

                    if (reader.IsDBNull(reader.GetOrdinal("MEDIAITEMID")))
                    {
                        dalMediaitem.Mediaitemid = 0;
                    }
                    else
                    {
                        dalMediaitem.Mediaitemid = Convert.ToInt32(reader["MEDIAITEMID"]);
                    }
                    if (reader.IsDBNull(reader.GetOrdinal("MEDIACATEGORYID")))
                    {
                        dalMediaitem.Mediacategoryid = 0;
                    }
                    else
                    {
                        dalMediaitem.Mediacategoryid = Convert.ToInt32(reader["MediacategoryID"]);
                    }



                    mediaitems.Add(dalMediaitem);
                }
            }
            catch (Exception exc)
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
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_Like WHERE MEDIAITEMID = :mediaitemid AND USERID = :userid";
                cmd.Parameters.AddWithValue("mediaitemID", mediaitemid);
                cmd.Parameters.AddWithValue("Userid", userid);
    

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception exc)
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
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_Like WHERE MEDIACATEGORYID = :mediaitemid AND USERID = :userid";
                cmd.Parameters.AddWithValue("mediaitemID", mediaitemid);
                cmd.Parameters.AddWithValue("Userid", userid);


                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public void AddReport(int mediaitemid, int userid)
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS2_REPORTED(mediaitemID, Userid) VALUES (:mediaitemID, :Userid)";
                //cmd.CommandText = "INSERT INTO PTS2_REPORTED(mediaitemID, Userid) VALUES (:mediaitemID, :Userid) WHERE NOT EXISTS (SELECT * FROM PTS2_REPORTED WHERE MEDIAITEMID = :mediaitemID AND USERID = :Userid)";
                cmd.Parameters.AddWithValue("mediaitemID", mediaitemid);
                cmd.Parameters.AddWithValue("Userid", userid);


                db.Connection.Open();
 
                cmd.ExecuteReader();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public List<Report> Getallreports()
        {
           
            reports = new List<Report>();
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PTS2_REPORTED";
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    dalReport = new Report();
                    dalReport.UserID = Convert.ToInt32(reader["USERID"]);
                    dalReport.ReportedID = Convert.ToInt32(reader["REPORTEDID"]);
                    if (reader.IsDBNull(reader.GetOrdinal("MEDIAITEMID")))
                    {
                    dalReport.MediaitemID = 0;
                    }
                    else
                    {
                    dalReport.MediaitemID = Convert.ToInt32(reader["MEDIAITEMID"]);
                    }
                  



                    reports.Add(dalReport);
                    
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return reports;
        }

        public Report GetSingleReport(int mediaitemid, int userid)
        {
            dalSingleReport = new Report();
            reports = new List<Report>();
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PTS2_REPORTED WHERE MEDIAITEMID = :mediaitemid AND USERID = :userid";
                cmd.Parameters.AddWithValue("mediaitemID", mediaitemid);
                cmd.Parameters.AddWithValue("Userid", userid);

                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    dalSingleReport = new Report();

                    if (reader.IsDBNull(reader.GetOrdinal("REPORTEDID")))
                    {
                        dalSingleReport.ReportedID = 0;
                        
                    }
                    else
                    {
                        dalSingleReport.ReportedID = Convert.ToInt32(reader["REPORTEDID"]); 
                    }
                    if (reader.IsDBNull(reader.GetOrdinal("MEDIAITEMID")))
                    {
                        dalSingleReport.MediaitemID = 0;
                    }
                    else
                    {
                        dalSingleReport.MediaitemID = Convert.ToInt32(reader["MEDIAITEMID"]);
                    }
                    
                    if (reader.IsDBNull(reader.GetOrdinal("USERID")))
                    {
                        dalSingleReport.UserID = 0;
                    }
                    else
                    {
                        dalSingleReport.UserID = Convert.ToInt32(reader["USERID"]);
                    }


                    reports.Add(dalSingleReport);

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return dalSingleReport;
        }

        public List<string> GetAllCategories()
        {

            Categories = new List<string>();
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PTS2_MEDIACATEGORY";
           

                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    string Categoryname = Convert.ToString(reader["MEDIACATEGORYNAME"]);


                    Categories.Add(Categoryname);

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return Categories;
        }

        public void RemoveReportedFile(int mediaitemid, int userid)
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_REPORTED WHERE MEDIAITEMID = :MediaitemID AND USERID = :userid";
                cmd.Parameters.AddWithValue("MediaitemID", mediaitemid);
                cmd.Parameters.AddWithValue("Userid", userid);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public int GetMediaCategory(string naam)
        {
      
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = " SELECT MEDIACATEGORYID FROM PTS2_MEDIACATEGORY WHERE MEDIACATEGORYNAME = :naam";
                cmd.Parameters.AddWithValue("MEDIACATEOGRYNAME", naam);

                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   categoryid = Convert.ToInt32(reader["MEDIACATEGORYID"]);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return categoryid;
        }

        public List<Mediaitem> SearchOnTitle(string Title)
        {

            mediaitems = new List<Mediaitem>();
            try
            {
                Title = "%" + Title + "%";
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PTS2_MEDIAITEM WHERE TITLE LIKE :Title";
                cmd.Parameters.AddWithValue("TITLE", Title);
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
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
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return mediaitems;
        }

        public List<Mediaitem> SearchOnCategory(string categorytitle)
        {

            mediaitems = new List<Mediaitem>();
            try
            {
                categorytitle = "%" + categorytitle + "%";
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT MI.MEDIAITEMID, MI.TITLE, MI.DESCRIPTION, MI.USERID FROM PTS2_MEDIAITEM MI, PTS2_MEDIAITEMFILE MF, PTS2_MEDIACATEGORY MC WHERE MI.MEDIAITEMID = MF.MEDIAITEMID AND MF.MEDIACATEGORYID = MC.MEDIACATEGORYID AND MEDIACATEGORYNAME LIKE :categorytitle";


                cmd.Parameters.AddWithValue("categorytitle", categorytitle);
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
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
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return mediaitems;
        }

        public int GetUserID(int itemid)
        {
            
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT USERID FROM PTS2_MEDIAITEM WHERE MEDIAITEMID = :itemid";
                cmd.Parameters.AddWithValue("itemid", itemid);
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

               
                    UserID = Convert.ToInt32(reader["USERID"]);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return UserID;
        }

    }
}
