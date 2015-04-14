using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace Datalayer
{
   public class DbMaterial 
    {
        private Databaseconnection db = new Databaseconnection();
        private OracleConnection DbMaterial;

        public DbMaterial()
        {
            DbMaterial = new OracleConnection();
            DbMaterial.ConnectionString = db.getstring();
        }

       public void ChangePrice(string MaterialName, double Price)
        {
            try
            {
                OracleCommand cmd = this.DbMaterial.CreateCommand();
                cmd.CommandText = "update PTS2_MATERIAL set price = :Price where materialName = :MaterialName";
                cmd.Parameters.Add("materialName", MaterialName);
                cmd.Parameters.Add("price", Price);

                DbMaterial.Open();

                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.DbMaterial.Close();
            }
        }
    }
}
