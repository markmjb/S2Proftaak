using System.Collections.Generic;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbReservation: Databaseconnection
    {
        private Databaseconnection db;
        private readonly OracleConnection dbr;


        public DbReservation()
        {
            db = new Databaseconnection();
            this.dbr = new OracleConnection();
            dbr.ConnectionString = db.getstring();
        }


        public List<int> Campspots()
        {
            OracleCommand cmd = this.dbr.CreateCommand();
            return null;
        }
    }
}
