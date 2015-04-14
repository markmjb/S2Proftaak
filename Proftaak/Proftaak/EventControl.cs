using System;
using Businesslayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class EventControl : Form
    {
        //FIELDS
        private Businesslayer.EventControl eventControl = new Businesslayer.EventControl();
        
        //CONSTRUCTORS
        public EventControl()
        {
            InitializeComponent();
        }

        private void EventControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        //METHODS
        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string description = tbDescription.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            decimal ticketPrice = nupTicketprice.Value;
            string country = tbCountry.Text;
            string province = tbProvince.Text;
            string city = tbCity.Text;
            string street = tbStreet.Text;
            int streetnumber = Convert.ToInt32(nupStreetnumber.Value);
            string postalcode = tbPostalcode.Text;

            eventControl.CreateEvent(name, description, startDate, endDate, ticketPrice, country, province, city, street, streetnumber, postalcode);
        }
    }
}
