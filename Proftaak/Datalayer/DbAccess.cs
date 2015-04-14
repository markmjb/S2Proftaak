using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
    public class DbAccess
    {
        private Databaseconnection db = new Databaseconnection();
        private OracleConnection DbAcces;

        public DbAccess()
        {
            DbAcces = new OracleConnection();
            DbAcces.ConnectionString = db.getstring();
        }

        public void DeleteRes(int ResNr)
        {
            try
            {

                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "  DELETE FROM PTS2_Reservation R WHERE R.ID = ':ID'";
                cmd.Parameters.Add("ID", ResNr);

                DbAcces.Open();
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


        public void DeleteUserRes(int ResNr)
        {
            try
            {

                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "  DELETE FROM PTS2_User_Reservation UR WHERE UR.ReservationID = ':ID'";
                cmd.Parameters.Add("ID", ResNr);

                DbAcces.Open();
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

        public List<ReservationAccesDL> AllReservations(int EventID)
        {

            List<ReservationAccesDL> Reservations = new List<ReservationAccesDL>();

            try
            {
                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "SELECT R.ReservationID, R.Price FROM PTS2_Reservation R, PTS2_Event E WHERE R.EventID = E.EventID AND E.EventID = :ID";
                cmd.Parameters.Add("ID", EventID);

                DbAcces.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                int ReservationNr;
                int Price;

                while (reader.Read())
                {
                    ReservationNr = Convert.ToInt32(reader["ReservationID"]);
                    Price = Convert.ToInt32(reader["Price"]);
                    ReservationAccesDL Reservation = new ReservationAccesDL(ReservationNr, Price);
                    Reservations.Add(Reservation);
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.DbAcces.Close();
            }
            return Reservations;
        }

        public void AcceptPaymentRes(int ResNr)
        {
            /*
            try
            {

                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "  DELETE FROM PTS2_Reservation R WHERE R.ID = ':ID'";
                cmd.Parameters.Add("ID", ResNr);

                DbAcces.Open();
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
             * 
             */
        }

        public void AttachRFID(int ResNr)
        {
            /*
            try
            {

                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "  DELETE FROM PTS2_Reservation R WHERE R.ID = ':ID'";
                cmd.Parameters.Add("ID", ResNr);

                DbAcces.Open();
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
            */
        }
    }
}
