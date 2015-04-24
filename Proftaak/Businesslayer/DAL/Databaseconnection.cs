using Oracle.DataAccess.Client;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Businesslayer.DAL
{
    public class Databaseconnection
    {
        public OleDbConnection Connection { get; set; }
        public static string Connectionstring
        {
            get { return "User Id=mark;Password=mark;Data Source=172.21.144.1:1521;SERVICE NAME=orcl;"; }
            private set {  }
        }
        //  get{return "User Id=dbi311717;Password=NDnMEa7VWMV;Data Source=" + "192.168.21.50/fhictora" + ";"; }
        //get{return "User Id=mark;Password=mark;Data Source=" + "127.0.0.1/" + ";"; }

        public Databaseconnection()
        {
            Connection = new OleDbConnection("Provider=OraOLEDB.Oracle;DATA SOURCE=ORCL;USER ID=SYSTEM;PASSWORD=Paashaas1");
            
        }
    }
}