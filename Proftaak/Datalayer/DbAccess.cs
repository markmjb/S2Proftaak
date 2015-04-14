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

        //Databaseconnection db = new Databaseconnection();

        public void DeleteRes(string ResNr)
        {
            try
            {
                Openconnection();
                CMD().CommandText =
                    "DELETE FROM Reservation, User_Reservation WHERE Reservation.ID = '" + ResNr + "' AND User_Reservation.ReservationID = '" + ResNr + "';";
                CMD().Parameters.Add("ID", ResNr);

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
