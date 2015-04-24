using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using Businesslayer.Business;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace Businesslayer.DAL
{
    public class DbReservation
    {
        private Databaseconnection db;
        private IList<Campspot> spots;
        private Campspot singlespot;
        private IList<Group> groups;
        private int returnint;

        public DbReservation()
        {
            db = new Databaseconnection();
        }


        public BindingList<Campspot> Campspots(int evid)
        {
            spots = new BindingList<Campspot>();


            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                string sql = "select C.CAMPINGSPOTID,C.CAMPPLACE,C.DESCRIPTION" +
                             ",C.CAMPINGSPOTTYPE,C.PRICEPERDAY FROM PTS2_CAMPINGSPOT C FULL JOIN" +
                             " PTS2_EVENT_CAMPINGSPOT ON PTS2_EVENT_CAMPINGSPOT.CAMPINGSPOTID" +
                             " = C.CAMPINGSPOTID WHERE EVENTID=:evid AND C.CAMPINGSPOTID" +
                             " NOT IN (Select CAMPSPOTID FROM PTS2_RESCAMP WHERE RESID IN (SELECT RESID FROM PTS2_RESERVATION))";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("evid", evid);
                this.db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    singlespot = new Campspot();
                    singlespot.CampspotId = Convert.ToInt32(reader["CAMPINGSPOTID"]);
                    singlespot.Campplace = Convert.ToInt32(reader["CAMPPLACE"]);
                    singlespot.Description = Convert.ToString(reader["Campingspottype"]);
                    singlespot.Campingspottype = Convert.ToString(reader["CAMPINGSPOTTYPE"]);
                    singlespot.Price = Convert.ToDecimal(reader["PRICEPERDAY"]);
                    spots.Add(singlespot);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return (BindingList<Campspot>) spots;

        }

        public BindingList<Campspot> FilterCampspots(int evid, string filter)
        {
            spots = new BindingList<Campspot>();
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                string sql = "select C.CAMPINGSPOTID,C.CAMPPLACE,C.DESCRIPTION" +
                             ",C.CAMPINGSPOTTYPE,C.PRICEPERDAY FROM PTS2_CAMPINGSPOT C FULL JOIN" +
                             " PTS2_EVENT_CAMPINGSPOT ON PTS2_EVENT_CAMPINGSPOT.CAMPINGSPOTID" +
                             " = C.CAMPINGSPOTID WHERE EVENTID=:evid AND CAMPINGSPOTTYPE=:ctype AND C.CAMPINGSPOTID" +
                             " NOT IN (Select CAMPSPOTID FROM PTS2_RESCAMP WHERE RESID IN (SELECT RESID FROM PTS2_RESERVATION))";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("evid", evid);
                cmd.Parameters.AddWithValue("ctype", filter);
                this.db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    singlespot = new Campspot();
                    singlespot.CampspotId = Convert.ToInt32(reader["CAMPINGSPOTID"]);
                    singlespot.Campplace = Convert.ToInt32(reader["CAMPPLACE"]);
                    singlespot.Description = Convert.ToString(reader["Campingspottype"]);
                    singlespot.Campingspottype = Convert.ToString(reader["CAMPINGSPOTTYPE"]);
                    singlespot.Price = Convert.ToDecimal(reader["PRICEPERDAY"]);
                    spots.Add(singlespot);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return (BindingList<Campspot>)spots;

        }

        public BindingList<Group> GetAllGroups()
        {
            try
            {
                groups= new BindingList<Group>();
                Group group = new Group();
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "Select * from PTS2_GROUP";
                this.db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    group = new Group();
                    group.ID = Convert.ToInt32(reader["GROUPID"]);
                    group.Name = Convert.ToString(reader["GROUPNAME"]);
                    groups.Add(group);
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
            return groups as BindingList<Group>;

        }

        public bool Groupexists(string text)
        {
            bool exists = false;
            try
            {

                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select * from PTS2_Group where Groupname=:GID";
                cmd.Parameters.AddWithValue("GID", text);
                this.db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
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
            return exists;

        }

        public void Creategroup(string text)
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "insert INTO PTS2_GROUP(GROUPNAME) VALUES (:groupname)";
                cmd.Parameters.AddWithValue("groupname", text);
                this.db.Connection.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }

        }

        public int SelectMaxID()
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select Max(RESERVATIONID) FROM PTS2_RESERVATION";
                this.db.Connection.Open();
                returnint = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
            return returnint;

        }

        public void Insertreservation(Event _event, decimal totalprice)
        {
            try { 
            OleDbCommand cmd = this.db.Connection.CreateCommand();
            cmd.CommandText =
                "INSERT INTO PTS2_RESERVATION (STARTDATE,ENDDATE,PRICE,EVENTID) VALUES (:datestart,:dateend,:totalprice,:evid)";
            cmd.Parameters.AddWithValue("datestart", _event.StartDate);
            cmd.Parameters.AddWithValue("dateend", _event.EndDate);
            cmd.Parameters.AddWithValue("totalprice", totalprice);
            cmd.Parameters.AddWithValue("evid", _event.EventID);
            this.db.Connection.Open();
            cmd.ExecuteNonQuery();
                }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public void Insertreservation2(int resid, int campspotId)
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS2_RESCAMP(RESID,CAMPSPOTID) VALUES (:RES,:CAMP)";
                cmd.Parameters.AddWithValue("RES", resid);
                cmd.Parameters.AddWithValue("CAMP", campspotId);
                this.db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
            }

        public void Insertreservation3(int id, int resid)
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS2_USER_RESERVATION(USERID,RESERVATIONID) VALUES (:usid,:resid)";
                cmd.Parameters.AddWithValue("usid", id);
                cmd.Parameters.AddWithValue("resid", resid);
               
                this.db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public void InsertUser(User user)
        {
            try{
            OleDbCommand cmd = this.db.Connection.CreateCommand();
            cmd.CommandText =
                "INSERT INTO PTS2_USER(FIRSTNAME,LASTNAME,EMAIL,UPAS,GROUPID,ADDRESSID) VALUES (:firstname,:lastname,:email,:upas,:groupid,:addressid)";
                cmd.Parameters.AddWithValue("FIRSTNAME",user.Firstname);
                cmd.Parameters.AddWithValue("LASTNAME",user.Lastname);
                cmd.Parameters.AddWithValue("EMAIL",user.Email);
                cmd.Parameters.AddWithValue("upas", user.Password);
                cmd.Parameters.AddWithValue("groupid", user.Group.ID);
                cmd.Parameters.AddWithValue("addressid", user.Address.AddressID);
            this.db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public void insertAddress(Address address)
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO PTS2_ADDRESS(COUNTRY,PROVINCE,CITY,STREET,HOUSENUMBER,POSTALCODE) VALUES (:country,:prov,:city,:street,:housenumber,:postalcode)";
                cmd.Parameters.AddWithValue("country", address.Country);
                cmd.Parameters.AddWithValue("prov", address.Province);
                cmd.Parameters.AddWithValue("city", address.City);
                cmd.Parameters.AddWithValue("street", address.Street);
                cmd.Parameters.AddWithValue("housenumber", address.Streetnumber);
                cmd.Parameters.AddWithValue("postalcode", address.PostalCode);
                this.db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
        }

        public int GetAddressID()
        {
            returnint = 0;
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select Max(ADDRESSID) FROM PTS2_ADDRESS";
                this.db.Connection.Open();
                returnint = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
            return returnint;
        }

        public int GetUserID()
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select Max(USERID) FROM PTS2_USER";
                this.db.Connection.Open();
                returnint = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
            return returnint;
        }

        public int GetReservationID()
        {
            try
            {
                OleDbCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select Max(RESERVATIONID) FROM PTS2_RESERVATION";
                this.db.Connection.Open();
                returnint = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
            return returnint;
        }

        public void UpdateDebt(int userID, decimal priceperuser, int EventID)
        {
            try{
            OleDbCommand cmd = this.db.Connection.CreateCommand();
            cmd.CommandText = "insert into pts2_debt(userid,eventid,amount) VALUES (:userid,:evid,:amount)";
            cmd.Parameters.AddWithValue("userid", userID);
            cmd.Parameters.AddWithValue("evid", EventID);
            cmd.Parameters.AddWithValue("amount", priceperuser);
            this.db.Connection.Open();
            cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
        }
        }
    }

