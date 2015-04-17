using System;
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
            List<int> spots = new List<int>();
            try
            {
                OracleCommand cmd = this.dbr.CreateCommand();
                cmd.CommandText =
                    "select CAMPINGSPOTID from PTS2_CAMPINGSPOT INNER JOIN PTS2_RESCAMP ON PTS2_CAMPINGSPOT.CAMPINGSPOTID=PTS2_RESCAMP.CAMPSPOTID";
                this.dbr.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    spots.Add(Convert.ToInt32(reader["CAMPINGSPOTID"]));
                }
            }
            catch (OracleException exc)
            {

            }
            finally
            {
                this.dbr.Close();
            }
            return spots;

        }
    }
}
