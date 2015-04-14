using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.AccessControl;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Oracle.DataAccess.Client;

namespace Datalayer
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
    }
}
