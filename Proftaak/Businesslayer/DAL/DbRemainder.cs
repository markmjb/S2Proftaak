using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbRemainder
    {
        private readonly Databaseconnection db;
        private bool Logincheck;

        public DbRemainder()
        {
          db = new Databaseconnection();
        }

        public bool Checklogin(string email, string pass)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select userid from PTS2_user where EMAIL= :email and Userpassword=:pw";
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pw", pass);
                this.db.Connection.Open();
               
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Logincheck = true;
                    
                }
                else
                {
                    Logincheck = false;
                }
            }
            catch (OracleException exception)
            {
            Console.WriteLine(exception);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return Logincheck;


        }
        public User Getloggeduser(string email, string pass)
        {
            User user = new User();
            Address address = new Address();
            List<string> Objects = new List<string>();
            try
            {
               OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText =
                    "select U.userid,U.firstname,U.lastname,U.email,A.Street,A.Housenumber,A.postalcode,A.city,A.province,A.country from PTS2_user U,PTS2_Address A where U.ADDRESSID=A.ADDRESSID and U.EMAIL=:emo and U.USERPASSWORD=:upass";
                cmd.Parameters.Add("emo", email);
                cmd.Parameters.Add("upass", pass);
                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   user.ID = Convert.ToInt32(reader["USERID"]);
                   user.Firstname = Convert.ToString(reader["FIRSTNAME"]);
                   user.Lastname = Convert.ToString(reader["LASTNAME"]);
                   user.Email = Convert.ToString(reader["EMAIL"]);
                   address.Street = Convert.ToString(reader["STREET"]);
                   address.Streetnumber = Convert.ToInt32(reader["HOUSENUMBER"]);
                   address.PostalCode = Convert.ToString(reader["POSTALCODE"]);
                   address.City = Convert.ToString(reader["CITY"]);
                   address.Province = Convert.ToString(reader["PROVINCE"]);
                   address.Country = Convert.ToString(reader["COUNTRY"]);
                    user.Address = address;
                }
            }
            
            catch (OracleException exc)
            {

            }
            finally
            {
                this.db.Connection.Close();
                
            }

            return user;
        }
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText =
                    "SELECT E.eventID, E.eventName, E.description, E.startDate, E.endDate, E.ticketPrice, E.userID, A.addressID, A.country, A.province, A.city, A.street, A.housenumber, A.postalcode FROM PTS2_EVENT E, PTS2_ADDRESS A WHERE E.addressID = A.addressID";

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int eventID = Convert.ToInt32(reader["eventID"]);
                    string name = Convert.ToString(reader["eventName"]);
                    string description = Convert.ToString(reader["description"]);
                    DateTime startDate = Convert.ToDateTime(reader["startDate"]);
                    DateTime endDate = Convert.ToDateTime(reader["endDate"]);
                    decimal ticketPrice = Convert.ToDecimal(reader["ticketPrice"]);
                    int userID = Convert.ToInt32(reader["userID"]);

                    int addressID = Convert.ToInt32(reader["addressID"]);
                    string street = Convert.ToString(reader["street"]);
                    int streetnumber = Convert.ToInt32(reader["housenumber"]);
                    string postalCode = Convert.ToString(reader["postalcode"]);
                    string city = Convert.ToString(reader["city"]);
                    string province = Convert.ToString(reader["province"]);
                    string country = Convert.ToString(reader["country"]);

                    events.Add(new Event(eventID, name, description, startDate, endDate, ticketPrice, userID, addressID,
                        street, streetnumber, postalCode, city, province, country));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }

            return events;
        }

        public bool CheckEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {            
            bool result = false;

            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(eventID) as count FROM PTS2_EVENT WHERE eventName = :name AND description = :description AND startDate = TO_DATE(:startDate, 'MM/DD/YYYY') AND endDate = TO_DATE(:endDate, 'MM/DD/YYYY') AND ticketPrice = :ticketPrice";
                cmd.Parameters.Add("name", name);
                cmd.Parameters.Add("description", description);
                cmd.Parameters.Add("startDate", startDate.ToShortDateString());
                cmd.Parameters.Add("endDate", endDate.ToShortDateString());
                cmd.Parameters.Add("ticketPrice", ticketPrice);

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                reader.Read();
                if (Convert.ToInt32(reader["count"]) > 0)
                {
                    result = true;
                }  
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;  
        }

        public bool CheckAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            bool result = false;

            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(addressID) as count FROM PTS2_ADDRESS WHERE country = :country AND province = :province AND city = :city AND street = :street AND houseNumber = :streetnumber AND postalcode = :postalcode";
                cmd.Parameters.Add("country", country);
                cmd.Parameters.Add("province", province);
                cmd.Parameters.Add("city", city);
                cmd.Parameters.Add("street", street);
                cmd.Parameters.Add("streetnumber", streetnumber);
                cmd.Parameters.Add("postalcode", postalcode);

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                reader.Read();
                if (Convert.ToInt32(reader["count"]) > 0)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }

        public void CreateAddress(string country , string province , string city , string street , int streetnumber , string postalcode)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS2_ADDRESS (country, province, city, street, housenumber, postalcode) VALUES (:country, :province, :city, :street, :housenumber, :postalcode)";
                cmd.Parameters.Add("country", country);
                cmd.Parameters.Add("province", province);
                cmd.Parameters.Add("city", city);
                cmd.Parameters.Add("street", street);
                cmd.Parameters.Add("streetnumber", streetnumber);
                cmd.Parameters.Add("postalcode", postalcode);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, int addressID)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS2_Event (eventName, description, startDate, endDate, ticketPrice, userID, addressID) VALUES (:name, :description, TO_DATE(:startDate, 'MM/DD/YYYY'), TO_DATE(:endDate, 'MM/DD/YYYY'), :ticketPrice, :userID, :addressID)";
                cmd.Parameters.Add("name", name);
                cmd.Parameters.Add("description", description);
                cmd.Parameters.Add("startDate", startDate.ToShortDateString());
                cmd.Parameters.Add("endDate", endDate.ToShortDateString());
                cmd.Parameters.Add("ticketPrice", ticketPrice);
                cmd.Parameters.Add("userID", Userlogin.Loggeduser.ID);
                cmd.Parameters.Add("addressID", addressID);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        public int GetAddressID(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            int addressID = -1;

            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT addressID FROM PTS2_ADDRESS WHERE country = :country AND province = :province AND city = :city AND street = :street AND housenumber = :streetnumber AND postalcode = :postalcode";
                cmd.Parameters.Add("country", country);
                cmd.Parameters.Add("province", province);
                cmd.Parameters.Add("city", city);
                cmd.Parameters.Add("street", street);
                cmd.Parameters.Add("streetnumber", streetnumber);
                cmd.Parameters.Add("postalcode", postalcode);

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    addressID = Convert.ToInt32(reader["addressID"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception)
                {
                }
            }
            return addressID;
        }

        public int GetEventID(string eventName, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            int eventID = -1;

            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT eventID FROM PTS2_EVENT WHERE eventName = :eventName AND description = :description AND startDate = TO_DATE(:startDate, 'MM/DD/YYYY') AND endDate = TO_DATE(:endDate, 'MM/DD/YYYY') AND ticketPrice = :ticketPrice";
                cmd.Parameters.Add("eventName", eventName);
                cmd.Parameters.Add("description", description);
                cmd.Parameters.Add("startDate", startDate.ToShortDateString());
                cmd.Parameters.Add("endDate", endDate.ToShortDateString());
                cmd.Parameters.Add("ticketPrice", ticketPrice);

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    eventID = Convert.ToInt32(reader["eventID"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception)
                {
                }
            }
            return eventID;
        }

        public void DeleteEvent(int eventID)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "DELETE FROM PTS2_EVENT WHERE eventID = :eventID";
                cmd.Parameters.Add("eventID", eventID);

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    db.Connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
