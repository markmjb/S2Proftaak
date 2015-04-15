using System;

namespace Businesslayer.Business
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
        public int ReservationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

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

        public User(string firstname, string lastname, Address address, string email, int id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Email = email;
            ID = id;
        }

        public User(int reservationid, int userid, string lastname, string firstname, string email, string password, bool isAdmin, DateTime startdate, DateTime enddate, Address address, Group group )
        {
            ReservationID = reservationid;
            ID = userid;
            Lastname = lastname;
            Firstname = firstname;
            Address = address;
            Group = group;
            Isadmin = isAdmin;
            Email = email;
            Password = password;
            StartDate = startdate;
            EndDate = enddate;
        }

        public User()
        {
            
        }
    }
}
