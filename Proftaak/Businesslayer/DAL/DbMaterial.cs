using System;
using System.Collections.Generic;
using Businesslayer.Business;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

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
                while (reader.Read())
                {
                Item item = new Item();
                item.Name = Convert.ToString(reader["materialtypeName"]);
                item.Price= Convert.ToInt32(reader["price"]);
                items.Add(item);               
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
            return items;
        }
       public List<Item> GetStockItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                OracleCommand cmd = this.db.Connection.CreateCommand();
                cmd.CommandText = "SELECT MT.materialtypeName, M.Price, M.MaterialID FROM PTS2_Materialtype MT, PTS2_Material M WHERE MT.materialTypeID = M.MaterialTypeID AND M.MaterialID NOT IN (SELECT materialID FROM PTS2_LOAN)";

                db.Connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                string materialtypeName;
                int materialID;
                int price;

                while (reader.Read())
                {
                    materialtypeName = Convert.ToString(reader["materialtypeName"]);
                    price = Convert.ToInt32(reader["price"]);
                    materialID = Convert.ToInt32(reader["MaterialID"]);
                    Item item = new Item(materialtypeName, price, materialID);
                    items.Add(item);               
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
            catch (Exception exc)
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
                catch (Exception exc)
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
           catch (Exception exc)
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
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
       public int UpdateTotalPrice(string materialName)
       {
           int price = 0;
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "select price from PTS2_MATERIALTYPE where materialtypeName = :materialName";
               cmd.Parameters.Add("materialName", materialName);

               db.Connection.Open();
               OracleDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                   price = Convert.ToInt32(reader["price"]);
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
           return price;
       }
       public void GiveUserDept(int userId, int eventId, int debt)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "UPDATE PTS2_DEBT SET amount = :debt WHERE userID = :usID AND EventID = :evID";
               cmd.Parameters.Add("debt", debt);
               cmd.Parameters.Add("usID", userId);
               cmd.Parameters.Add("evID", eventId);

               db.Connection.Open();
               cmd.ExecuteNonQuery();
           }
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
       public User GetRFIDuser(string RFID)
      {
          User RFIDuser = null;
          try
          {
              OracleCommand cmd = this.db.Connection.CreateCommand();
              cmd.CommandText = "SELECT R.ReservationID, U.userID, U.lastName, U.firstName, U.Email, U.isAdmin, U.upas, U.isPresent, R.StartDate, R.endDate, G.Groupname, A.Street, A.Housenumber, A.Postalcode, A.Province, A.City, A.Country, D.Amount FROM PTS2_GROUP G, PTS2_USER U, PTS2_ADDRESS A, PTS2_RESERVATION R, PTS2_DEBT D, PTS2_USER_RESERVATION UR, PTS2_RFID RF WHERE G.GroupID = U.GroupID AND A.AddressID = U.AddressID AND D.UserID = U.UserID AND UR.UserID = U.UserID AND UR.ReservationID = R.ReservationID AND RF.UserID = U.UserID AND RF.RFID = :riID";

              cmd.Parameters.Add("riID", RFID);

              db.Connection.Open();
              OracleDataReader reader = cmd.ExecuteReader();

              int ReservationNr;
              int UserID;
              string LastName;
              string FirstName;
              string Email;
              bool isAdmin = false;
              bool isPresent = false;
              string UserPassword;
              DateTime StartDate;
              DateTime EndDate;
              string Groupname;
              string Street;
              int Housenumber;
              string Postalcode;
              string Province;
              string City;
              string Country;
              decimal Debt;

              while (reader.Read())
              {
                  ReservationNr = Convert.ToInt32(reader["ReservationID"]);
                  LastName = Convert.ToString(reader["lastname"]);
                  FirstName = Convert.ToString(reader["firstname"]);
                  UserID = Convert.ToInt32(reader["UserID"]);
                  Email = Convert.ToString(reader["Email"]);
                  if ((Convert.ToInt32(reader["isAdmin"])) == 0)
                  {
                      isAdmin = false;
                  }
                  else if ((Convert.ToInt32(reader["isAdmin"])) == 1)
                  {
                      isAdmin = true;
                  }
                  if ((Convert.ToInt32(reader["isPresent"])) == 0)
                  {
                      isPresent = false;
                  }
                  else if ((Convert.ToInt32(reader["isPresent"])) == 1)
                  {
                      isPresent = true;
                  }
                  UserPassword = Convert.ToString(reader["upas"]);
                  StartDate = Convert.ToDateTime(reader["StartDate"]);
                  EndDate = Convert.ToDateTime(reader["EndDate"]);
                  Groupname = Convert.ToString(reader["Groupname"]);
                  Street = Convert.ToString(reader["street"]);
                  Housenumber = Convert.ToInt32(reader["Housenumber"]);
                  Postalcode = Convert.ToString(reader["Postalcode"]);
                  Province = Convert.ToString(reader["province"]);
                  City = Convert.ToString(reader["City"]);
                  Country = Convert.ToString(reader["Country"]);
                  Debt = Convert.ToDecimal(reader["amount"]);


                  Address Address = new Address(Street, Housenumber, Postalcode, City, Province, Country);
                  Group Group = new Group(Groupname);
                  User User = new User(ReservationNr, UserID, LastName, FirstName, Email, UserPassword, isAdmin, StartDate, EndDate, isPresent, Address, Group, Debt);
                  RFIDuser = User;
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
          return RFIDuser;
      }
       public int GetRFIDID(int UserID)
       {
           int RFIDID = 0;
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT RFIDID FROM PTS2_RFID WHERE UserID = :usID";
               cmd.Parameters.Add("usID", UserID);

               db.Connection.Open();
               cmd.ExecuteReader();
               OracleDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                   RFIDID = Convert.ToInt32(reader["RFIDID"]);
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
           return RFIDID;
       }
       public void UpdateLoan(int materialID, int RFIDID, int UserID, DateTime StartDate, DateTime Enddate)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_LOAN (materialID, rfidID, userID, startDate, endDate) VALUES (:maID, :rfID, :usID, :sDate, :eDate)";
               cmd.Parameters.Add("maID", materialID);
               cmd.Parameters.Add("rfID", RFIDID);
               cmd.Parameters.Add("usID", UserID);
               cmd.Parameters.Add("sDate", StartDate);
               cmd.Parameters.Add("eDate", Enddate);

               db.Connection.Open();
               cmd.ExecuteNonQuery();
           }
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
       public void DeleteLoan(int materialID, int RFIDID)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "DELETE FROM PTS2_LOAN WHERE materialID = :maID AND rfidID = :rfID";
               cmd.Parameters.Add("maID", materialID);
               cmd.Parameters.Add("rfID", RFIDID);

               db.Connection.Open();
               cmd.ExecuteNonQuery();
           }
           catch (Exception exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
       }
       public List<Item> GetReservedItems(int RFIDID)
       {
           List<Item> items = new List<Item>();
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "SELECT M.Price, MT.MaterialTypeName, L.StartDate, L.Enddate FROM PTS2_LOAN L, PTS2_MATERIAL M, PTS2_MATERIALTYPE MT WHERE L.MaterialID = M.MaterialID AND M.MaterialtypeID = MT.MaterialtypeID AND L.RFIDID = :rfID";
               cmd.Parameters.Add("rfID", RFIDID);

               db.Connection.Open();
               cmd.ExecuteReader();
               OracleDataReader reader = cmd.ExecuteReader();

               string materialtypeName;
               int price;
               DateTime StartDate;
               DateTime EndDate;

               while (reader.Read())
               {
                   materialtypeName = Convert.ToString(reader["materialtypeName"]);
                   price = Convert.ToInt32(reader["price"]);
                   StartDate = Convert.ToDateTime(reader["StartDate"]);
                   EndDate = Convert.ToDateTime(reader["endDate"]);

                   Item item = new Item(materialtypeName, price, StartDate, EndDate);
                   items.Add(item);
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
           return items;
       }
    }
}
