using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public abstract class Reserveration
    {
        public DateTime BeginTime { get; set; }
        public DateTime Endtime { get; set; }
        public User Employee { get; set; }

        protected Reserveration(DateTime beginTime, DateTime endtime, User employee)
        {
            BeginTime = beginTime;
            Endtime = endtime;
            Employee = employee;
        }
    }
}
