using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
   public class ReservationMaterial: Reservation
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }

       public ReservationMaterial(DateTime beginTime, DateTime endtime, User employee, int amount, decimal price) : base(beginTime, endtime, employee)
       {
           Amount = amount;
           Price = price;
       }
        public void ChangePrice()
        {
            
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
