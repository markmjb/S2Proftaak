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
        private OracleConnection conn;

        public Databaseconnection()
        {
                conn = new OracleConnection();
                string user = "system";
                string pw = "system";
                conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + "127.0.0.1/" + ";";
        }

        public void Openconnection()
        {
            this.conn.Open();
        }

        public OracleCommand CMD()
        {
            OracleCommand cmd = this.conn.CreateCommand();
            return cmd;
        }

        public void Closeconnection()
        {
            this.conn.Close();
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
        //    {
        //        conn.Close();
        //    }

        //    return DCommentList;
        //}

    }
}

