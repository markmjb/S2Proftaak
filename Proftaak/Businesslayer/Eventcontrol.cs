using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    class EventControl
    {
        public User Employee { get; set; }
        public string Description { get; set; }
        public Address LocationAddress { get; set; }
        public string Name { get; set; }
        public string RFID { get; set; }

        public EventControl(User employee, string description, Address locationAddress, string name, string rfid)
        {
            Employee = employee;
            Description = description;
            LocationAddress = locationAddress;
            Name = name;
            RFID = rfid;
        }



    }
}
