using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbRemainder : Databaseconnection
    {
        private Databaseconnection db = new Databaseconnection();
        private readonly OracleConnection dbremainderconn;
        private bool Logincheck;

        public DbRemainder()
        {
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

        public List<Event> RefreshEvents()
        {
            List<Event> events = new List<Event>();

            int eventID;
            string eventName;
            string description;
            DateTime startDate;
            DateTime endDate;
            decimal ticketPrice;
            int userID;
            int addressID;

            string street = "";
            int streetnumber = -1;
            string postalCode = "";
            string city = "";
            string province = "";
            string country = "";

            try
            {
                OracleCommand cmd = this.dbremainderconn.CreateCommand();
                cmd.CommandText =
                    "SELECT eventID, eventName, description, startDate, endDate, ticketPrice, userID, addressID" +
                    " FROM PTS2_EVENT";
                dbremainderconn.Open();
                
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    eventID = Convert.ToInt32(reader["eventID"]);
                    eventName = Convert.ToString(reader["eventName"]);
                    description = Convert.ToString(reader["description"]);
                    startDate = Convert.ToDateTime(reader["startDate"]);
                    endDate = Convert.ToDateTime(reader["endDate"]);
                    ticketPrice = Convert.ToDecimal(reader["ticketPrice"]);
                    userID = Convert.ToInt32(reader["userID"]);
                    addressID = Convert.ToInt32(reader["addressID"]);

                    OracleCommand cmd2 = this.dbremainderconn.CreateCommand();
                    cmd.CommandText =
                        "SELECT country, province, city, street, housenumber, postalcode" +
                        " FROM PTS2_ADDRESS" +
                        " WHERE addressID = " +
                        addressID;
                    reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        street = Convert.ToString(reader["street"]);
                        streetnumber = Convert.ToInt32(reader["housenumber"]);
                        postalCode = Convert.ToString(reader["postalcode"]);
                        city = Convert.ToString(reader["city"]);
                        province = Convert.ToString(reader["province"]);
                        country = Convert.ToString(reader["country"]);
                    }

                    //events.Add(new Event(eventID, eventName, description, startDate, endDate, ticketPrice, userID,
                    //    addressID, street, streetnumber, postalCode, city, province, country));
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                try
                {
                    dbremainderconn.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return events;
        }
    }
}
