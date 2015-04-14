using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class ReservationAccesDL
    {
        public int ReservationNr { get; set; }
        public int Payment { get; set; }

        public ReservationAccesDL( int reservationNr, int payment )
	    {
            ReservationNr = reservationNr;
            Payment = payment;
	    }
    }
}
