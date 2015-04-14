using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public abstract class Reservation
    {
        public DateTime BeginTime { get; set; }
        public DateTime Endtime { get; set; }
        public User Employee { get; set; }

        protected Reservation(DateTime beginTime, DateTime endtime, User employee)
        {
            BeginTime = beginTime;
            Endtime = endtime;
            Employee = employee;
        }

        protected Reservation()
        {
            
        }
    }
}
