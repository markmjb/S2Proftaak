using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class EventControl : Reservation
    {
        public string Description { get; set; }
        public Address LocationAddress { get; set; }
        public string Name { get; set; }
        public string RFID { get; set; }

        public EventControl(DateTime beginTime, DateTime endtime, User employee, string description, Address locationAddress, string name, string rfid) : base(beginTime, endtime, employee)
        {
            Description = description;
            LocationAddress = locationAddress;
            Name = name;
            RFID = rfid;
        }



    }
}
