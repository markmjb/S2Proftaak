using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
    public class Databaseconnection
    {
        public List<EventDL> events = new List<EventDL>(); 
        public static string connectionstring = "User Id=mark;Password=mark;Data Source=" + "127.0.0.1/" + ";";
        public Databaseconnection()
        {

        }

        public string getstring()
        {
            return connectionstring;
        }

    }
}




//public List<DatalayerComment> CommentsOfFile(string item)
//{
//    string selectString = "SELECT * FROM PTS_COMMENTFILE WHERE SUBJECT Like '" + item + "%'";
//    this.command = new OracleCommand(selectString, this.conn);
//    DCommentList = new List<DatalayerComment>();
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
//            DCommentList.Add(new Datalayer.DatalayerComment(Commentid, Subject, Username, Description));
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