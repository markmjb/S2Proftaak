using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
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
                cmd.CommandText = "DELETE FROM PTS2_Reservation R WHERE R.ReservationID = :ID";
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
                cmd.CommandText = "  DELETE FROM PTS2_User_Reservation UR WHERE UR.ReservationID = :ID";
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

        public List<ReservationAccess> AllReservations(int EventID)
        {

            List<ReservationAccess> Reservations = new List<ReservationAccess>();

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
                    ReservationAccess Reservation = new ReservationAccess(ReservationNr, Price);
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

        public List<User> ReservationUser(int ResNr)
        {
            List<User> ReservUsers = new List<User>();

            try
            {
                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "SELECT R.ReservationID, U.userID, U.lastName, U.firstName, U.Email, U.isAdmin, U.UserPassword, R.StartDate, R.endDate, G.Groupname, A.Street, A.Housenumber, A.Postalcode, A.Province, A.City, A.Country FROM PTS2_GROUP G, PTS2_USER U, PTS2_ADDRESS A, PTS2_RESERVATION R WHERE G.GroupID = U.GroupID AND A.AddressID = U.AddressID AND U.UserID = R.UserID AND R.ReservationID = :ID";
                cmd.Parameters.Add("ID", ResNr);

                DbAcces.Open();
                OracleDataReader reader = cmd.ExecuteReader();


                int ReservationNr;
                int UserID;
                string LastName;
                string FirstName;
                string Email;
                bool isAdmin = false;
                string UserPassword;
                DateTime StartDate;
                DateTime EndDate;
                string Groupname;
                string Street;
                int Housenumber;
                string Postalcode;
                string Province;
                string City;
                string Country;


                while (reader.Read())
                {
                    ReservationNr = Convert.ToInt32(reader["ReservationID"]);
                    LastName = Convert.ToString(reader["lastname"]);
                    FirstName = Convert.ToString(reader["firstname"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    Email = Convert.ToString(reader["Email"]);
                    if ( (Convert.ToInt32(reader["isAdmin"])) == 0 )
                    {
                        isAdmin = false;
                    }
                    else if ((Convert.ToInt32(reader["isAdmin"])) == 1)
                    {
                        isAdmin = true;
                    }
                    UserPassword = Convert.ToString(reader["UserPassword"]);
                    StartDate = Convert.ToDateTime(reader["StartDate"]);
                    EndDate = Convert.ToDateTime(reader["EndDate"]);
                    Groupname = Convert.ToString(reader["Groupname"]);
                    Street = Convert.ToString(reader["street"]);
                    Housenumber = Convert.ToInt32(reader["Housenumber"]);
                    Postalcode = Convert.ToString(reader["Postalcode"]);
                    Province = Convert.ToString(reader["province"]);
                    City = Convert.ToString(reader["City"]);
                    Country = Convert.ToString(reader["Country"]);


                    Address Address = new Address(Street, Housenumber, Postalcode, City, Province, Country);
                    Group Group = new Group(Groupname);
                    User User = new User(ReservationNr,  UserID, LastName, FirstName, Email, UserPassword, isAdmin, StartDate, EndDate, Address, Group);
                    ReservUsers.Add(User);
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
            return ReservUsers;
            
        }

        public void AcceptPaymentRes(int ResNr)
        {
            /*
            try
            {

                OracleCommand cmd = this.DbAcces.CreateCommand();
                cmd.CommandText = "SELECT R.Price FROM PTS2_Reservation R WHERE R.ReservationID = :ID AND R.EventID = :ID";
                                  "UPDATE PTS2_Reservation SET isPayed = 1, Price = 0 WHERE R.ReservationID = :ID AND R.EventID = :ID";
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
