﻿using System.Collections.Generic;
using Businesslayer.Business;

namespace Businesslayer.DAL
{
    public class Databaseconnection
    {
        public List<EventControl> events = new List<EventControl>(); 
        public static string connectionstring = "User Id=system;Password=iPhone4SS;Data Source=" + "127.0.0.1/" + ";";
        public Databaseconnection()
        {

        }

        public string getstring()
        {
            return connectionstring;
        }

    }
}




//public List<BusinesslayerComment> CommentsOfFile(string item)
//{
//    string selectString = "SELECT * FROM PTS_COMMENTFILE WHERE SUBJECT Like '" + item + "%'";
//    this.command = new OracleCommand(selectString, this.conn);
//    DCommentList = new List<BusinesslayerComment>();
//    try
//    {
//        this.conn.Open();
//        OracleDataReader reader = this.command.ExecuteReader();

//        while (reader.Read())
//        {
//            int Commentid = Convert.ToInt32(reader["COMMENTID"]);
//            string Subject = Convert.ToString(reader["SUBJECT"]);
//            string Username = Convert.ToString(reader["USERNAME"]);
//            string Description = Convert.ToString(reader["DESCRIPTION"]);
//            DCommentList.Add(new Businesslayer.BusinesslayerComment(Commentid, Subject, Username, Description));
//        }
//    }
//    catch (OracleException exc)
//    {
//        Console.WriteLine(exc);
//    }
//    finally
//    { //        conn.Close();
//    }

//    return DCommentList;
//}