using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class ReservationAcces
    {
        public int ReservationNr { get; set; }
        public int Payment { get; set; }

        public ReservationAcces( int reservationNr, int payment )
	    {
            ReservationNr = reservationNr;
            Payment = payment;
	    }
    }
}
