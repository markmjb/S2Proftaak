namespace Businesslayer.Business
{
    public class ReservationAccess
    {
        public int ReservationNr { get; set; }
        public int Payment { get; set; }

        public ReservationAccess( int reservationNr, int payment )
	    {
            ReservationNr = reservationNr;
            Payment = payment;
	    }
        public override string ToString()
        {
            return ReservationNr + "\t|  payment: " + Payment;
        }
    }
}
