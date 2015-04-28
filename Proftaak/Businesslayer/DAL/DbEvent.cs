using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Businesslayer.Business;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace Businesslayer.DAL
{
    public class DbEvent
    {
        private readonly Databaseconnection db;
        public DbEvent()
        {
          db = new Databaseconnection();
        }      
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
            
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "SELECT E.eventID, E.eventName, E.description, E.startDate, E.endDate, E.ticketPrice, E.userID, A.addressID, A.country, A.province, A.city, A.street, A.housenumber, A.postalcode FROM PTS2_EVENT E, PTS2_ADDRESS A WHERE E.addressID = A.addressID";
                
                db.Connection.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event ev = new Event();
                    Address adress = new Address();

                    ev.EventID = Convert.ToInt32(reader["eventID"]);
                    ev.Name = Convert.ToString(reader["eventName"]);
                    ev.Description = Convert.ToString(reader["description"]);
                    ev.StartDate = Convert.ToDateTime(reader["startDate"]);
                    ev.EndDate = Convert.ToDateTime(reader["endDate"]);
                    ev.TicketPrice = Convert.ToDecimal(reader["ticketPrice"]);
                    ev.UserID = Convert.ToInt32(reader["userID"]);

                    adress.AddressID = Convert.ToInt32(reader["addressID"]);
                    adress.Street = Convert.ToString(reader["street"]);
                    adress.Streetnumber = Convert.ToInt32(reader["housenumber"]);
                    adress.PostalCode = Convert.ToString(reader["postalcode"]);
                    adress.City = Convert.ToString(reader["city"]);
                    adress.Province = Convert.ToString(reader["province"]);
                    adress.Country = Convert.ToString(reader["country"]);

                    ev.Address = adress;

                    events.Add(ev);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Connection.Close();
            }

            return events;
        }

        public bool CheckAddress(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            bool result = false;

            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                
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
               db.Connection.Close();
            }
            return result;
        }

        public void CreateAddress(string country , string province , string city , string street , int streetnumber , string postalcode)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                
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
               db.Connection.Close();
            }
        }

        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, int addressID)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                
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
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public int GetAddressID(string country, string province, string city, string street, int streetnumber, string postalcode)
        {
            int addressID = -1;

            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                
                cmd.CommandText = "SELECT addressID FROM PTS2_ADDRESS WHERE country = :country AND province = :province AND city = :city AND street = :street AND housenumber = :streetnumber AND postalcode = :postalcode";
                cmd.Parameters.Add("country", country);
                cmd.Parameters.Add("province", province);
                cmd.Parameters.Add("city", city);
                cmd.Parameters.Add("street", street);
                cmd.Parameters.Add("streetnumber", streetnumber);
                cmd.Parameters.Add("postalcode", postalcode);

                db.Connection.Open();
                
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
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
                catch (Exception e)
                {
                    throw e;
                }
            }
            return addressID;
        }

        public void DeleteEvent(int eventID)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();
                
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
                db.Connection.Close();
            }
        }

        public void EditEvent(int eventID, string columnName, string columnValue)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();

                if (columnName == "eventName")
                {
                    cmd.CommandText = "UPDATE PTS2_EVENT SET eventName = :columnValue WHERE eventID = :eventID";
                    cmd.Parameters.Add("columnValue", columnValue);
                    cmd.Parameters.Add("eventID", eventID);
                }
                else if (columnName == "startDate")
                {
                    cmd.CommandText =
                        "UPDATE PTS2_EVENT SET startDate = TO_DATE(:columnValue, 'MM/DD/YYYY') WHERE eventID = :eventID";
                    cmd.Parameters.Add("columnValue", columnValue);
                    cmd.Parameters.Add("eventID", eventID);
                }
                else if (columnName == "endDate")
                {
                    cmd.CommandText =
                        "UPDATE PTS2_EVENT SET endDate = TO_DATE(:columnValue, 'MM/DD/YYYY') WHERE eventID = :eventID";
                    cmd.Parameters.Add("columnValue", columnValue);
                    cmd.Parameters.Add("eventID", eventID);
                }
                else if (columnName == "description")
                {
                    cmd.CommandText = "UPDATE PTS2_EVENT SET description = :columnValue WHERE eventID = :eventID";
                    cmd.Parameters.Add("columnValue", columnValue);
                    cmd.Parameters.Add("eventID", eventID);
                }

                db.Connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public void EditEvent(int eventID, string columnName, decimal columnValue)
        {
            try
            {
                OracleCommand cmd = db.Connection.CreateCommand();

                cmd.CommandText = "UPDATE PTS2_EVENT SET ticketPrice = :columnValue WHERE eventID = :eventID";
                cmd.Parameters.Add("columnValue", columnValue);
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
                db.Connection.Close();
            }
        }
    }
}
