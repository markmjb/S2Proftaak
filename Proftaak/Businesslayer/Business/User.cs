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
        public decimal Debt { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public int ReservationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Birthdate { get; set; } 
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

        public User(int reservationid, int userid, string lastname, string firstname, string email, string password, bool isAdmin, DateTime startdate, DateTime enddate, bool isPresent, Address address, Group group, decimal debt )
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
            IsPresent = isPresent;
            Debt = debt;
        }

        public User()
        {
            
        }

        public User(string firstname, string lastname, Address address, string email, string password, Group group, DateTime dateTime)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.Group = group;
            this.Birthdate = dateTime;
        }
        public override string ToString()
        {
            return ReservationID + "\t|  " + Lastname + "," + Firstname + "  debt: " + Debt;
        }
    }
}
