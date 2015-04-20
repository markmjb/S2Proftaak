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
       public void ReturnMaterial(int materialID, string materialName, string description, double price, int materialTypeID, int eventID)
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_MATERIAL (materialID, materialName, description, price, materialTypeID, eventID)VALUES (:materialID, :materialName, :description, :price, :materialTypeID, :eventID)";
               cmd.Parameters.Add("materialID", materialID);
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
           catch (OracleException exc)
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
               cmd.ExecuteScalar();
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
       public void GetReservedItems()
       {
           List<ReservationMaterial> Reservations = new List<ReservationMaterial>();
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
                   //items.Add(item);
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
          catch (OracleException exc)
          {
              Console.WriteLine(exc);
          }
          finally
          {
              db.Connection.Close();
          }
          return RFIDuser;
      }
       public void UpdateLoan(int materialID, int RFIDID, int UserID, DateTime StartDate, DateTime Enddate )
       {
           try
           {
               OracleCommand cmd = this.db.Connection.CreateCommand();
               cmd.CommandText = "INSERT INTO PTS2_LOAN (materialID, rfidID, userID, startDate, endDate) VALUES (:mID, :rID, :uID, TO_DATE(:sDate, 'MM/DD/YYYY'), TO_DATE(:eDate, 'MM/DD/YYYY'))";
               cmd.Parameters.Add("mID", materialID);
               cmd.Parameters.Add("rID", RFIDID);
               cmd.Parameters.Add("uID", UserID);
               cmd.Parameters.Add("sDate", StartDate);
               cmd.Parameters.Add("eDate", Enddate);

               db.Connection.Open();
               cmd.ExecuteNonQuery();
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
           catch (OracleException exc)
           {
               Console.WriteLine(exc);
           }
           finally
           {
               this.db.Connection.Close();
           }
           return RFIDID;
       }

       //SELECT COUNT(L.RFIDID) As Aantal, MT.MaterialTypeName FROM PTS2_LOAN L, PTS2_MATERIAL M, PTS2_MATERIALTYPE MT WHERE L.MaterialID = M.MaterialID AND M.MaterialtypeID = MT.MaterialtypeID GROUP BY MT.MaterialTypeName;

    }
}
