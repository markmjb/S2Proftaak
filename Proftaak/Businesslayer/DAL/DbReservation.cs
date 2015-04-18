using System;
using System.Collections.Generic;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbReservation
    {
        private Databaseconnection db;

        public DbReservation()
        {
            db= new Databaseconnection();
        }


        public List<int> Campspots()
        {
            List<int> spots = new List<int>();
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText =
                    "select CAMPPLACE FROM PTS2_CAMPINGSPOT INNER JOIN PTS2_EVENT ON CAMPINGSPOTID = PTS2_CAMPINGSPOT.CAMPINGSPOTID AND EVENTID=1";
                this.db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    spots.Add(Convert.ToInt32(reader["CAMPPLACE"]));
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return spots;

        }
    }
}
