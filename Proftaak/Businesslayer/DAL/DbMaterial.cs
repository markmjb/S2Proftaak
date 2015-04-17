using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
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

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                OracleCommand cmd = this.DbMateriall.CreateCommand();
                cmd.CommandText = "select materialtypeName, price from PTS2_MATERIALTYPE";

                DbMateriall.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                string materialtypeName;
                decimal price;

                while (reader.Read())
                {
                    materialtypeName = Convert.ToString(reader["materialtypeName"]);
                    price = Convert.ToDecimal(reader["price"]);
                    Item item = new Item(materialtypeName, price);
                    items.Add(item);               
                }
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.DbMateriall.Close();
            }
            return items;
        }
       public void ChangePrice(string MaterialName, decimal Price)
        {
            try
            {
                OracleCommand cmd = this.DbMateriall.CreateCommand();
                cmd.CommandText = "update PTS2_MATERIAL set price =:Price where materialName = :MaterialName";
                cmd.Parameters.Add("MaterialName", MaterialName);
                cmd.Parameters.Add("Price", Price);
                

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
