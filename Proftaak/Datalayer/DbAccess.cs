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
        public DbAccess()
        {

        }

        public void DeleteRes(int ResNr)
        {
            try
            {
                CMD().CommandText =
                    "DELETE FROM Reservation, User_Reservation WHERE Reservation.ID = '" + ResNr + "' AND User_Reservation.ReservationID = '" + ResNr + "'";
                CMD().Parameters.Add("ID", ResNr);

                Openconnection();

                CMD().ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                Closeconnection();
            }
        }
    }
}
