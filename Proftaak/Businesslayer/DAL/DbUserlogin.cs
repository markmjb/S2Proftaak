using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslayer.Business;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace Businesslayer.DAL
{
    class DbUserlogin
    {
        private readonly Databaseconnection db;
        private bool Logincheck;

        public DbUserlogin()
        {
            db = new Databaseconnection();
        }
        public bool Checklogin(string email, string pass)
        {

            try
            {
                OleDbCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "select userid from PTS2_user where EMAIL= :email and upas=:pw and isAdmin = 1";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("pw", pass);
                db.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Logincheck = true;

                }
                else
                {
                    Logincheck = false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                db.Connection.Close();
            }
            return Logincheck;


        }
        public User Getloggeduser(string email, string pass)
        {
            User user = new User();
            Address address = new Address();
            try
            {
                OleDbCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText =
                    "select U.userid,U.firstname,U.lastname,U.email,U.upas,U.Isadmin,A.Street,A.Housenumber,A.postalcode,A.city,A.province,A.country from PTS2_user U,PTS2_Address A where U.ADDRESSID=A.ADDRESSID and U.EMAIL=:emo and U.upas=:upass";
                cmd.Parameters.AddWithValue("emo", email);
                cmd.Parameters.AddWithValue("upass", pass);
                db.Connection.Open();
                try
                {
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.ID = Convert.ToInt32(reader["USERID"]);
                        user.Firstname = Convert.ToString(reader["FIRSTNAME"]);
                        user.Lastname = Convert.ToString(reader["LASTNAME"]);
                        user.Email = Convert.ToString(reader["EMAIL"]);
                        user.Password = Convert.ToString(reader["upas"]);
                        int I = Convert.ToInt32(reader["Isadmin"]);
                        if (I==1)
                        {
                            user.Isadmin = true;
                        }
                        if (I == 0)
                        {
                            user.Isadmin = false;
                        }
                        address.Street = Convert.ToString(reader["STREET"]);
                        address.Streetnumber = Convert.ToInt32(reader["HOUSENUMBER"]);
                        address.PostalCode = Convert.ToString(reader["POSTALCODE"]);
                        address.City = Convert.ToString(reader["CITY"]);
                        address.Province = Convert.ToString(reader["PROVINCE"]);
                        address.Country = Convert.ToString(reader["COUNTRY"]);
                        user.Address = address;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.Connection.Close();
            }

            return user;

        }
        public void Changepass(int UserID, string newpass)
        {
            try
            {
                OleDbCommand cmd2 = db.Connection.CreateCommand();
                string sql = string.Format("Update PTS2_User set upas='{0}' where UserID={1}", newpass, UserID);
                cmd2.CommandText = sql;
                db.Connection.Open();
                cmd2.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                throw exception;
            }

            finally
            {
                db.Connection.Close();
            }
        }
    }
}
