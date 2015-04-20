using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Businesslayer.Business;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class DbReservation
    {
        private Databaseconnection db;
        private List<Campspot> spots;
        private Campspot singlespot;
        private List<Group> groups;
        private int returnint;

        public DbReservation()
        {
            db = new Databaseconnection();
        }


        public List<Campspot> Campspots(int evid)
        {
            spots = new List<Campspot>();


            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                string sql = "select C.CAMPINGSPOTID,C.CAMPPLACE,C.DESCRIPTION" +
                             ",C.CAMPINGSPOTTYPE,C.PRICEPERDAY FROM PTS2_CAMPINGSPOT C FULL JOIN" +
                             " PTS2_EVENT_CAMPINGSPOT ON PTS2_EVENT_CAMPINGSPOT.CAMPINGSPOTID" +
                             " = C.CAMPINGSPOTID WHERE EVENTID=:evid AND C.CAMPINGSPOTID" +
                             " NOT IN (Select CAMPSPOTID FROM PTS2_RESCAMP WHERE RESID IN (SELECT RESID FROM PTS2_RESERVATION))";
                cmd.CommandText = sql;

                cmd.Parameters.Add("evid", evid);
                this.db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

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
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return spots;

        }

        public List<Campspot> FilterCampspots(int evid, string filter)
        {
            spots = new List<Campspot>();


            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                string sql = "select C.CAMPINGSPOTID,C.CAMPPLACE,C.DESCRIPTION" +
                             ",C.CAMPINGSPOTTYPE,C.PRICEPERDAY FROM PTS2_CAMPINGSPOT C FULL JOIN" +
                             " PTS2_EVENT_CAMPINGSPOT ON PTS2_EVENT_CAMPINGSPOT.CAMPINGSPOTID" +
                             " = C.CAMPINGSPOTID WHERE EVENTID=:evid AND CAMPINGSPOTTYPE=:ctype AND C.CAMPINGSPOTID" +
                             " NOT IN (Select CAMPSPOTID FROM PTS2_RESCAMP WHERE RESID IN (SELECT RESID FROM PTS2_RESERVATION))";
                cmd.CommandText = sql;
                cmd.Parameters.Add("evid", evid);
                cmd.Parameters.Add("ctype", filter);
                this.db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

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
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.db.Connection.Close();
            }
            return spots;

        }

        public List<Group> GetAllGroups()
        {
            try
            {
                groups = new List<Group>();
                Group group = new Group();
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "Select * from PTS2_GROUP";
                this.db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    group = new Group();
                    group.ID = Convert.ToInt32(reader["GROUPID"]);
                    group.Name = Convert.ToString(reader["GROUPNAME"]);
                    groups.Add(group);
                }
            }
            catch (OracleException e)
            {

                throw e;
            }
            finally
            {
                this.db.Connection.Close();
            }
            return groups;

        }

        public bool Groupexists(string text)
        {
            bool exists = false;
            try
            {

                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select * from PTS2_Group where Groupname=:GID";
                cmd.Parameters.Add("GID", text);
                this.db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                }
            }
            catch (OracleException e)
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
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "insert INTO PTS2_GROUP(GROUPNAME) VALUES (:groupname)";
                cmd.Parameters.Add("groupname", text);
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
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select Max(RESERVATIONID) FROM PTS2_RESERVATION";
                this.db.Connection.Open();
                returnint = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (OracleException e)
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
            OracleCommand cmd = this.db.Connection.CreateCommand();
            cmd.CommandText =
                "INSERT INTO PTS2_RESERVATION (STARTDATE,ENDDATE,PRICE) VALUES (:datestart,:dateend,:totalprice)";
            cmd.Parameters.Add("datestart", _event.StartDate);
            cmd.Parameters.Add("dateend", _event.EndDate);
            cmd.Parameters.Add("totalprice", totalprice);
            this.db.Connection.Open();
            cmd.ExecuteNonQuery();
                }
            catch (OracleException e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Open();
            }
        }

        public void Insertreservation2(int resid, int campspotId)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO (RESID,CAMPSPOTID) VALUES (:RES,:CAMP)";
                cmd.Parameters.Add("RES", resid);
                cmd.Parameters.Add("CAMP", campspotId);
                this.db.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                throw e;
            }
            finally
            {
                this.db.Connection.Open();
            }
            }

        public void Insertreservation3(int id, int resid)
        {
            OracleCommand cmd = this.db.Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO USER_RESERVATION";
            
        }
    }
}

