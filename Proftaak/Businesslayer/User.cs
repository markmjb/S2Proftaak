using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public  class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
        public Group Group { get; set; }
        public bool Isadmin { get; set; }
        public string Email { get; set; }
        public Decimal Debt { get; set; }
        public string Password { get; set; }

        public int ID { get; set; }

        public User(string firstname, string lastname, Address address, Group @group, bool isadmin, string email, decimal debt, string password, int ID )
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Group = group;
            Isadmin = isadmin;
            Email = email;
            Debt = debt;
            Password = password;
            this.ID = ID;
        }
    }
}
