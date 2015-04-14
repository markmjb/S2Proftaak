using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
    public class DbRemainder: Databaseconnection
    {
        //FIELDS
        private Databaseconnection db = new Databaseconnection();
        private OracleConnection dbremainderconn;

        //CONSTRUCTORS
        public DbRemainder()
        {
            dbremainderconn = new OracleConnection();
            dbremainderconn.ConnectionString = db.getstring();
        }

        //METHODS
        public void AddEvent()
        {
            
        }
    }
}
