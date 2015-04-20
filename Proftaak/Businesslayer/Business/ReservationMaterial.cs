using System;
using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
   public class ReservationMaterial: Reservation
    {
        DbMaterial DM = new DbMaterial();
        public int Amount { get; set; }
        public int Price { get; set; }

       public ReservationMaterial(DateTime beginTime, DateTime endtime, User employee, int amount, int price, Item item) : base(beginTime, endtime, employee)          
       {
           Amount = amount;
           Price = price;
       }
        public void ChangePrice(string name, int price)
        {
          // DM.ChangePrice(name, price);        
        }

        public void ChangeStock()
        {
            
        }
        public void LoanMaterial()
        {
            
        }
        public void ReturnMaterial()
        {

        }
    }
}
