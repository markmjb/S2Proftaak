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
using Businesslayer.Business;

namespace Proftaak
{
    public partial class EventControl : Form
    {
        //FIELDS
        private Businesslayer.Business.EventControl eventControl = new Businesslayer.Business.EventControl();
        
        //CONSTRUCTORS
        public EventControl()
        {
            InitializeComponent();

            FillDatagridEvents();
        }
        //EVENTS
        private void EventControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        //METHODS
        private void FillDatagridEvents()
        {
            datagridEvents.Rows.Clear();

            foreach (Event ev in eventControl.Events)
            {
                datagridEvents.Rows.Add(Convert.ToString(ev.EventID), Convert.ToString(ev.Name), Convert.ToString(ev.StartDate), Convert.ToString(ev.EndDate));
            }
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string description = tbDescription.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            decimal ticketPrice = nudTicketprice.Value;

            string country = tbCountry.Text;
            string province = tbProvince.Text;
            string city = tbCity.Text;
            string street = tbStreet.Text;
            int streetnumber = Convert.ToInt32(nudStreetnumber.Value);
            string postalcode = tbPostalcode.Text;

            if (name != "" && description != "" && startDate > DateTime.Today && endDate > DateTime.Today && endDate > startDate && country != "" && province != "" && city != "" && street != "" && streetnumber > 0 && postalcode != "")
            {
                if (!eventControl.CheckEvent(name, description, startDate, endDate, ticketPrice))
                {
                    if (!eventControl.CheckAddress(country, province, city, street, streetnumber, postalcode))
                    {
                        eventControl.CreateAddress(country, province, city, street, streetnumber, postalcode);
                    }

                    eventControl.CreateEvent(name, description, startDate, endDate, ticketPrice, eventControl.dbRemainder.GetAddressID(country, province, city, street, streetnumber, postalcode));
                }
            }
            FillDatagridEvents();
        }

        private void datagridEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && datagridEvents.CurrentCell.Value != "" && datagridEvents.CurrentCell.Value != null)
            {
                int eventID = Convert.ToInt32(datagridEvents.CurrentCell.Value);

                Event ev = eventControl.GetEvent(eventID);

                tbName.Text = ev.Name;
                tbDescription.Text = ev.Description;
                dtpStartDate.Value = ev.StartDate;
                dtpEndDate.Value = ev.EndDate;
                nudTicketprice.Value = ev.TicketPrice;

                tbCountry.Text = ev.Address.Country;
                tbProvince.Text = ev.Address.Province;
                tbCity.Text = ev.Address.City;
                tbStreet.Text = ev.Address.Street;
                nudStreetnumber.Value = ev.Address.Streetnumber;
                tbPostalcode.Text = ev.Address.PostalCode;
            }
        }
    }
}
