using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbRemainder : Databaseconnection
    {
        private Databaseconnection db;
        private readonly OracleConnection dbremainderconn;
        private bool Logincheck;

        public DbRemainder()
        {
            db = new Databaseconnection();
            this.dbremainderconn = new OracleConnection();
            dbremainderconn.ConnectionString = db.getstring();
        }

        public bool Checklogin(string email, string pass)
        {
            try
            {
                OracleCommand cmd = this.dbremainderconn.CreateCommand();
                cmd.CommandText = "select userid from PTS2_user where EMAIL= :email and Userpassword=:pw";
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pw", pass);
                dbremainderconn.Open();
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
            }
            finally
            {
                this.dbremainderconn.Close();
            }
            return Logincheck;


        }

        public List<string> Getloggeduser(string email, string pass)
        {
            List<string> Objects = new List<string>();
            try
            {
               OracleCommand cmd = this.dbremainderconn.CreateCommand();
                cmd.CommandText =
                    "select U.userid,U.firstname,U.lastname,U.email,A.Street,A.Housenumber,A.postalcode,A.city,A.province,A.country from PTS2_user U,PTS2_Address A where U.ADDRESSID=A.ADDRESSID and U.EMAIL=:emo and U.USERPASSWORD=:upass";
                cmd.Parameters.Add("emo", email);
                cmd.Parameters.Add("upass", pass);
                dbremainderconn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    String UID = Convert.ToString(reader["USERID"]);
                    String firstname = Convert.ToString(reader["FIRSTNAME"]);
                    String lastname = Convert.ToString(reader["LASTNAME"]);
                    String emaill = Convert.ToString(reader["EMAIL"]);
                    String street = Convert.ToString(reader["STREET"]);
                    String housenumber = Convert.ToString(reader["HOUSENUMBER"]);
                    String postalcode = Convert.ToString(reader["POSTALCODE"]);
                    String city = Convert.ToString(reader["CITY"]);
                    String state = Convert.ToString(reader["PROVINCE"]);
                    String country = Convert.ToString(reader["COUNTRY"]);
                    Objects.Add(UID);
                    Objects.Add(firstname);
                    Objects.Add(lastname);
                    Objects.Add(emaill);
                    Objects.Add(street);
                    Objects.Add(housenumber);
                    Objects.Add(postalcode);
                    Objects.Add(city);
                    Objects.Add(state);
                    Objects.Add(country);
                }
            }
            
            catch (OracleException exc)
            {

            }
            finally
            {
                this.dbremainderconn.Close();
                
            }

            return Objects;
        }

        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            try
            {
                OracleCommand cmd = this.dbremainderconn.CreateCommand();
                cmd.CommandText =
                    "SELECT E.eventID, E.eventName, E.description, E.startDate, E.endDate, E.ticketPrice, E.userID, A.addressID, A.country, A.province, A.city, A.street, A.housenumber, A.postalcode FROM PTS2_EVENT E, PTS2_ADDRESS A WHERE E.addressID = A.addressID";

                dbremainderconn.Open();
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
                try
                {
                    dbremainderconn.Close();
                }
                catch (Exception)
                {
                }
            }

            return events;
        }

        public bool CheckEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            int results = 0;
            string command = "COUNT(eventID) FROM PTS2_EVENT WHERE eventName = " + name + " AND description = " + description + " AND startDate = " + startDate + " AND endDate = " + endDate + " AND ticketPrice = " + ticketPrice;

            try
            {
                OracleCommand cmd = this.dbremainderconn.CreateCommand();
                cmd.CommandText = command;

                dbremainderconn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    results++;
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
                    dbremainderconn.Close();
                }
                catch (Exception)
                {
                }
            }

            if (results > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            int results = 0;
            string command = "COUNT(addressID) FROM PTS2_ADDRESS WHERE country = " + country + " AND province = " + province + " AND city = " + city + " AND street = " + street + " AND houseNumber = " + streetnumber + " AND postalcode = " + postalcode;
            
            try
            {
                OracleCommand cmd = this.dbremainderconn.CreateCommand();
                cmd.CommandText = command;

                dbremainderconn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    results++;
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
                    dbremainderconn.Close();
                }
                catch (Exception)
                {
                }
            }

            if (results > 0)
            {
                return true;
            }
            return false;
        }

    }
}
