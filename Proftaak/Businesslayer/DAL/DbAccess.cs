using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbAccess
    {
        private readonly Databaseconnection db;
        public DbAccess()
        {
            db = new Databaseconnection();
        }

        public void DeleteRes(int ResNr)
        {
            try
            {

                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_Reservation R WHERE R.ReservationID = :ID";
                cmd.Parameters.Add("ID", ResNr);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public void DeleteUserRes(int ResNr)
        {
            try
            {

                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "  DELETE FROM PTS2_User_Reservation UR WHERE UR.ReservationID = :ID";
                cmd.Parameters.Add("ID", ResNr);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public List<ReservationAccess> AllReservations(int EventID)
        {
            List<ReservationAccess> Reservations = new List<ReservationAccess>();

            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT R.ReservationID, R.Price FROM PTS2_Reservation R, PTS2_Event E WHERE R.EventID = E.EventID AND E.EventID = :ID";
                cmd.Parameters.Add("ID", EventID);

                db.Connection.Open();
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
                db.Connection.Close();
            }
            return Reservations;
        }

        public List<ReservationAccess> Search(int EventID, int Search)
        {
            List<ReservationAccess> Reservations = new List<ReservationAccess>();
            string search = Convert.ToString(Search);
            search = search + "%";

            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT R.ReservationID, R.Price FROM PTS2_Reservation R, PTS2_Event E WHERE R.EventID = E.EventID AND E.EventID = :eID AND R.ReservationID LIKE :Search";
                cmd.Parameters.Add("eID", EventID);
                cmd.Parameters.Add("Search", Search);

                db.Connection.Open();
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
                this.db.Connection.Close();
            }
            return Reservations;
        }

        public List<User> AllUsers(int EventID)
        {
            List<User> ReservUsers = new List<User>();

            try
            {

                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT R.ReservationID, U.userID, U.lastName, U.firstName, U.Email, U.isAdmin, U.upas, U.isPresent, R.StartDate, R.endDate, G.Groupname, A.Street, A.Housenumber, A.Postalcode, A.Province, A.City, A.Country, D.amount FROM PTS2_GROUP G, PTS2_USER U, PTS2_ADDRESS A, PTS2_RESERVATION R, PTS2_DEBT D, PTS2_USER_RESERVATION UR WHERE G.GroupID = U.GroupID AND A.AddressID = U.AddressID AND D.UserID = U.UserID AND UR.UserID = U.UserID AND UR.ReservationID = R.ReservationID AND R.EventID = :eID";
                cmd.Parameters.Add("eID", EventID);

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                int ReservationNr;
                int UserID;
                string LastName;
                string FirstName;
                string Email;
                bool isAdmin = false;
                bool isPresent = false;
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
                decimal Debt;

                while (reader.Read())
                {
                    ReservationNr = Convert.ToInt32(reader["ReservationID"]);
                    LastName = Convert.ToString(reader["lastname"]);
                    FirstName = Convert.ToString(reader["firstname"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    Email = Convert.ToString(reader["Email"]);
                    if ((Convert.ToInt32(reader["isAdmin"])) == 0)
                    {
                        isAdmin = false;
                    }
                    else if ((Convert.ToInt32(reader["isAdmin"])) == 1)
                    {
                        isAdmin = true;
                    }
                    if ((Convert.ToInt32(reader["isPresent"])) == 0)
                    {
                        isPresent = false;
                    }
                    else if ((Convert.ToInt32(reader["isPresent"])) == 1)
                    {
                        isPresent = true;
                    }
                    UserPassword = Convert.ToString(reader["upas"]);
                    StartDate = Convert.ToDateTime(reader["StartDate"]);
                    EndDate = Convert.ToDateTime(reader["EndDate"]);
                    Groupname = Convert.ToString(reader["Groupname"]);
                    Street = Convert.ToString(reader["street"]);
                    Housenumber = Convert.ToInt32(reader["Housenumber"]);
                    Postalcode = Convert.ToString(reader["Postalcode"]);
                    Province = Convert.ToString(reader["province"]);
                    City = Convert.ToString(reader["City"]);
                    Country = Convert.ToString(reader["Country"]);
                    Debt = Convert.ToDecimal(reader["amount"]);

                    Address Address = new Address(Street, Housenumber, Postalcode, City, Province, Country);
                    Group Group = new Group(Groupname);
                    User User = new User(ReservationNr, UserID, LastName, FirstName, Email, UserPassword, isAdmin, StartDate, EndDate, isPresent, Address, Group, Debt);
                    ReservUsers.Add(User);
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
            return ReservUsers;
        }

        public List<User> ReservationUser(int ResNr)
        {
            List<User> ReservUsers = new List<User>();
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT R.ReservationID, U.userID, U.lastName, U.firstName, U.Email, U.isAdmin, U.upas, U.isPresent, R.StartDate, R.endDate, G.Groupname, A.Street, A.Housenumber, A.Postalcode, A.Province, A.City, A.Country, D.Amount FROM PTS2_GROUP G, PTS2_USER U, PTS2_ADDRESS A, PTS2_RESERVATION R, PTS2_DEBT D, PTS2_USER_RESERVATION UR WHERE G.GroupID = U.GroupID AND A.AddressID = U.AddressID AND D.UserID = U.UserID AND UR.UserID = U.UserID AND UR.ReservationID = R.ReservationID AND R.ReservationID = :ID";

                cmd.Parameters.Add("ID", ResNr);

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                int ReservationNr;
                int UserID;
                string LastName;
                string FirstName;
                string Email;
                bool isAdmin = false;
                bool isPresent = false;
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
                decimal Debt;

                while (reader.Read())
                {
                    ReservationNr = Convert.ToInt32(reader["ReservationID"]);
                    LastName = Convert.ToString(reader["lastname"]);
                    FirstName = Convert.ToString(reader["firstname"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    Email = Convert.ToString(reader["Email"]);
                    if ((Convert.ToInt32(reader["isAdmin"])) == 0)
                    {
                        isAdmin = false;
                    }
                    else if ((Convert.ToInt32(reader["isAdmin"])) == 1)
                    {
                        isAdmin = true;
                    }
                    if ((Convert.ToInt32(reader["isPresent"])) == 0)
                    {
                        isPresent = false;
                    }
                    else if ((Convert.ToInt32(reader["isPresent"])) == 1)
                    {
                        isPresent = true;
                    }
                    UserPassword = Convert.ToString(reader["upas"]);
                    StartDate = Convert.ToDateTime(reader["StartDate"]);
                    EndDate = Convert.ToDateTime(reader["EndDate"]);
                    Groupname = Convert.ToString(reader["Groupname"]);
                    Street = Convert.ToString(reader["street"]);
                    Housenumber = Convert.ToInt32(reader["Housenumber"]);
                    Postalcode = Convert.ToString(reader["Postalcode"]);
                    Province = Convert.ToString(reader["province"]);
                    City = Convert.ToString(reader["City"]);
                    Country = Convert.ToString(reader["Country"]);
                    Debt = Convert.ToDecimal(reader["amount"]);


                    Address Address = new Address(Street, Housenumber, Postalcode, City, Province, Country);
                    Group Group = new Group(Groupname);
                    User User = new User(ReservationNr, UserID, LastName, FirstName, Email, UserPassword, isAdmin, StartDate, EndDate, isPresent, Address, Group, Debt);
                    ReservUsers.Add(User);
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
            return ReservUsers;
        }

        public void ShowUserDept(int ResNr, int UserID)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT R.Price FROM PTS2_Reservation R WHERE R.ReservationID = :ID AND R.EventID = :ID";
                cmd.Parameters.Add("ID", ResNr);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public void AttachRFID(int UserID, int EventID, string RFID)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS2_RFID (rfid, isAttached, eventID, userID) VALUES (:RFID,1,:EventID,:UserID)";
                cmd.Parameters.Add("RFID", RFID);
                cmd.Parameters.Add("EventID", EventID);
                cmd.Parameters.Add("UserID", UserID);

                db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public void DettachRFID(int EventID, string RFID)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();

                cmd.CommandText = "DELETE FROM PTS2_RFID WHERE RFID = :RFID AND EventID = :EventID";
                cmd.Parameters.Add("RFID", RFID);
                cmd.Parameters.Add("EventID", EventID);

                db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exc)
            {
                throw exc;
            }
            finally
            {
                db.Connection.Close();
            }

        }

        public bool GetRFIDStatus(string RFID)
        {
            bool isAttached = false;
            try
            {

                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT isAttached FROM PTS2_RFID WHERE RFID = :rID";
                cmd.Parameters.Add("rID", RFID);

                db.Connection.Open();
                cmd.ExecuteReader();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if ((Convert.ToInt32(reader["isAttached"])) == 0)
                    {
                        isAttached = false;
                    }
                    else if ((Convert.ToInt32(reader["isAttached"])) == 1)
                    {
                        isAttached = true;
                    }
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
            return isAttached;
        }

        public bool GetuserRFID(int UserID)
        {
            bool isAttached = false;
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT isAttached FROM PTS2_RFID WHERE UserID = :UserID";
                cmd.Parameters.Add("UserID", UserID);

                db.Connection.Open();
                cmd.ExecuteReader();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if ((Convert.ToInt32(reader["isAttached"])) == 0)
                    {
                        isAttached = false;
                    }
                    else if ((Convert.ToInt32(reader["isAttached"])) == 1)
                    {
                        isAttached = true;
                    }
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
            return isAttached;
        }

        public bool IsPresent(int UserID)
        {
            bool isPresent = false;
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT isPresent FROM PTS2_USER WHERE UserID = :UserID";
                cmd.Parameters.Add("UserID", UserID);

                db.Connection.Open();
                cmd.ExecuteReader();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["isPresent"]) == 0)
                    {
                        isPresent = false;
                    }
                    else if (Convert.ToInt32(reader["isPresent"]) == 1)
                    {
                        isPresent = true;
                    }
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
            return isPresent;
        }

        public int UserRFID(string RFID)
        {
            int UserID = -1;
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT U.UserID FROM PTS2_User U, PTS2_RFID R WHERE U.UserID = R.UserID AND R.RFID = :rID";
                cmd.Parameters.Add("rID", RFID);

                db.Connection.Open();
                cmd.ExecuteReader();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserID = Convert.ToInt32(reader["UserID"]);
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
            return UserID;
        }

        public void UpdateisPresent(int UserID, bool isPresent)
        {
            int Present = 0;
            if (isPresent)
            {
                Present = 1;
            }
            else if (!isPresent)
            {
                Present = 0;
            }

            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "UPDATE PTS2_USER SET isPresent = :isPresent WHERE UserID = :userID";
                cmd.Parameters.Add("isPresent", Present);
                cmd.Parameters.Add("userID", UserID);

                db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public void AcceptPayment(int ResNr, decimal Price)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "UPDATE PTS2_Reservation SET Price = :Price WHERE ReservationID = :ID";
                cmd.Parameters.Add("Price", Price);
                cmd.Parameters.Add("ID", ResNr);

                db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public void AcceptDebt(int UserID, int EventID)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "UPDATE PTS2_Debt SET amount = 0 WHERE UserID = :usID AND EventID = :evID";
                cmd.Parameters.Add("usID", UserID);
                cmd.Parameters.Add("evID", EventID);

                db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }
        }
    }
}
