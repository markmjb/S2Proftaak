using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
    public class DbAccess : Datalayer.Databaseconnection
    {
        private Databaseconnection db = new Databaseconnection();
        private OracleConnection DbAcces;

        public DbAccess()
        {
            DbAcces = new OracleConnection();
            DbAcces.ConnectionString = db.getstring();
        }
        public void DeleteRes(string ResNr)
        {
            try
            {
                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "DELETE FROM Reservation, User_Reservation WHERE Reservation.ID = '" + ResNr + "' AND User_Reservation.ReservationID = '" + ResNr + "';";
                cmd.Parameters.Add("ID", ResNr);
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.DbAcces.Close();
            }
        }
    }
}
