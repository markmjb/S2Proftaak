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
    }
}

