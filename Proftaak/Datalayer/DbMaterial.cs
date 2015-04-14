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
        private OracleConnection DbMateriall;

        public DbMaterial()
        {
            DbMateriall = new OracleConnection();
            DbMateriall.ConnectionString = db.getstring();
        }

       public void ChangePrice(string MaterialName, double Price)
        {
            try
            {
                OracleCommand cmd = this.DbMateriall.CreateCommand();
                cmd.CommandText = "update PTS2_MATERIAL set price = :Price where materialName = :MaterialName";
                cmd.Parameters.Add("materialName", MaterialName);
                cmd.Parameters.Add("price", Price);

                DbMateriall.Open();

                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.DbMateriall.Close();
            }
        }
       public void AddStock(string MaterialName, string Description, double Price, int MaterialTypeID, int EventID)
       {
           try
           {
               OracleCommand cmd = this.DbMateriall.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_MATERIAL (materialName, description, price, materialTypeID, eventID)VALUES (:MaterialName, :Description, :Price, :MaterialTypeID, :EventID)";
               cmd.Parameters.Add("materialName", MaterialName);
               cmd.Parameters.Add("description", Description);
               cmd.Parameters.Add("price", Price);
               cmd.Parameters.Add("materialTypeID", MaterialTypeID);
               cmd.Parameters.Add("eventID", EventID);

               DbMateriall.Open();

               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.DbMateriall.Close();
           }
       }
       public void LoanMaterial(int MaterialID)
       {
           try
           {
               OracleCommand cmd = this.DbMateriall.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MATERIAL WHERE materialID = :MaterialID";
               cmd.Parameters.Add("materialID", MaterialID);              

               DbMateriall.Open();

               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.DbMateriall.Close();
           }
       }
       public void ReturnMaterial(int MaterialID, string MaterialName, string Description, double Price, int MaterialTypeID, int EventID)
       {
           try
           {
               OracleCommand cmd = this.DbMateriall.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_MATERIAL (materialID, materialName, description, price, materialTypeID, eventID)VALUES (:MaterialID, :MaterialName, :Description, :Price, :MaterialTypeID, :EventID)";
               cmd.Parameters.Add("materialID", MaterialID);
               cmd.Parameters.Add("materialName", MaterialName);
               cmd.Parameters.Add("description", Description);
               cmd.Parameters.Add("price", Price);
               cmd.Parameters.Add("materialTypeID", MaterialTypeID);
               cmd.Parameters.Add("eventID", EventID);

               DbMateriall.Open();

               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.DbMateriall.Close();
           }
       }
    }
}
