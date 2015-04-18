using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
   public class DbMaterial
   {
       private readonly Databaseconnection db;
        
        public DbMaterial()
        {
           db = new Databaseconnection();
        }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "select materialtypeName, price from PTS2_MATERIALTYPE";

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                string materialtypeName;
                int price;

                while (reader.Read())
                {
                    materialtypeName = Convert.ToString(reader["materialtypeName"]);
                    price = Convert.ToInt32(reader["price"]);
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
                this.db.Connection.Close();
            }
            return items;
        }
       public void ChangePrice(string materialName, int price)
        {
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = String.Format("update PTS2_MATERIALTYPE set price = {0} where materialtypeName = '{1}'", price, materialName);
               // cmd.CommandText = String.Format("update PTS2_MATERIAL set price = {0} where materialName = '{1}'", price, materialName);
                //cmd.Parameters.Add("materialName", materialName);
                //cmd.Parameters.Add("price", price);
                

                db.Connection.Open();

                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                try
                {
                    OracleCommand cmd = this.db.Connection.CreateCommand();
                    //cmd.CommandText = String.Format("update PTS2_MATERIALTYPE set price = {0} where materialtypeName = '{1}'", price, materialName);
                    cmd.CommandText = String.Format("update PTS2_MATERIAL set price = {0} where materialName = '{1}'", price, materialName);
                    //cmd.Parameters.Add("materialName", materialName);
                    //cmd.Parameters.Add("price", price);


                    //DbMateriall.Open();

                    cmd.ExecuteReader();
                }
                catch (OracleException exc)
                {
                    Console.WriteLine(exc);
                }
                finally
                {
                    this.db.Connection.Close();
                }
            }
        }
       public void AddStock(string materialName, string description, int price, int materialTypeID, int eventID)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_MATERIAL (materialName, description, price, materialTypeID, eventID)VALUES (:materialName, :description, :price, :materialTypeID, :eventID)";
               cmd.Parameters.Add("materialName", materialName);
               cmd.Parameters.Add("description", description);
               cmd.Parameters.Add("price", price);
               cmd.Parameters.Add("materialTypeID", materialTypeID);
               cmd.Parameters.Add("eventID", eventID);

               db.Connection.Open();

               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
       public void LoanMaterial(int MaterialID)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_MATERIAL WHERE materialID = :MaterialID";
               cmd.Parameters.Add("materialID", MaterialID);              

               db.Connection.Open();

               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
       public void ReturnMaterial(int MaterialID, string MaterialName, string Description, double Price, int MaterialTypeID, int EventID)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_MATERIAL (materialID, materialName, description, price, materialTypeID, eventID)VALUES (:MaterialID, :MaterialName, :Description, :Price, :MaterialTypeID, :EventID)";
               cmd.Parameters.Add("materialID", MaterialID);
               cmd.Parameters.Add("materialName", MaterialName);
               cmd.Parameters.Add("description", Description);
               cmd.Parameters.Add("price", Price);
               cmd.Parameters.Add("materialTypeID", MaterialTypeID);
               cmd.Parameters.Add("eventID", EventID);

               db.Connection.Open();

               cmd.ExecuteReader();
           }
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
    }
}
