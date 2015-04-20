using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

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
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText = "select userid from PTS2_user where EMAIL= :email and upas=:pw";
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pw", pass);
                db.Connection.Open();

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
                OracleCommand cmd = db.Connection.CreateCommand();
                cmd.CommandText =
                    "select U.userid,U.firstname,U.lastname,U.email,U.upas,U.Isadmin,A.Street,A.Housenumber,A.postalcode,A.city,A.province,A.country from PTS2_user U,PTS2_Address A where U.ADDRESSID=A.ADDRESSID and U.EMAIL=:emo and U.upas=:upass";
                cmd.Parameters.Add("emo", email);
                cmd.Parameters.Add("upass", pass);
                db.Connection.Open();
                try
                {
                    OracleDataReader reader = cmd.ExecuteReader();
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
                    throw;
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

            return user;

        }
        public void Changepass(int UserID, string newpass)
        {
            try
            {
                OracleCommand cmd2 = db.Connection.CreateCommand();
                string sql = string.Format("Update PTS2_User set upas='{0}' where UserID={1}", newpass, UserID);
                cmd2.CommandText = sql;
                db.Connection.Open();
                cmd2.ExecuteNonQuery();

            }
            catch (OracleException exception)
            {

            }

            finally
            {
                db.Connection.Close();
            }
        }
    }
}
