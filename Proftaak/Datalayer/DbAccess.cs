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
                cmd.CommandText = "  DELETE FROM PTS2_Reservation R WHERE R.ID = ':ID';";
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
                cmd.CommandText = "  DELETE FROM PTS2_User_Reservation UR WHERE UR.ReservationID = ':ID';";
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

        public void AllReservations(int ID)
        {
            /*try
            {
                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "SELECT R.ID, R.Price FROM Reservation R, Event E WHERE E.EventID = E.id AND E.ID = :ID";
                cmd.Parameters.Add("ID", ID);

                DbAcces.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                List<A> list = new List<A>();
                int ReserveringID;
                int Price;

                while (reader.Read())
                {
                    Episode = Convert.ToInt32(reader["Episode"]);
                    A AB = new A(....);
                    list.Add(AB);
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.DbAcces.Close();
            }*/
        }

        public void AcceptPaymentRes(int ResNr)
        {
            /*
            try
            {

                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "  DELETE FROM PTS2_Reservation R WHERE R.ID = ':ID';";
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
                cmd.CommandText = "  DELETE FROM PTS2_Reservation R WHERE R.ID = ':ID';";
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
