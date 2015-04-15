using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class EventDL
    {
        //FIELDS
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int UserID { get; set; }
        public AddressDL addresDL { get; set; }
        
        //CONSTRUCTORS
        public EventDL(int eventID, string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice, int userID, int addressID, string street, int streetnumber, string postalCode, string city, string province, string country)
        {
            EventID = eventID;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TicketPrice = ticketPrice;
            UserID = userID;
        
            addresDL = new AddressDL(addressID, street, streetnumber, postalCode, city, province, country);
        }

    }
}
