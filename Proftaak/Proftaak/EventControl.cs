using System;
using Businesslayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
        }

        //EVENTS
        private void EventControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        //METHODS
        private void RefreshData()
        {
            if (datagridEvents.RowCount > 0)
            {
                if (datagridEvents.CurrentCell.ColumnIndex == 0 && datagridEvents.CurrentCell.Value != null)
                {
                    int eventID = Convert.ToInt32(datagridEvents.CurrentCell.Value);

                    Event ev = eventControl.GetEvent(eventID);

                    if (ev != null)
                    {
                        lblEventIDValue.Text = Convert.ToString(ev.EventID);
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
                    else
                    {
                        lblEventIDValue.Text = "";
                        tbName.Text = "";
                        tbDescription.Text = "";
                        dtpStartDate.Value = DateTime.Now;
                        dtpEndDate.Value = DateTime.Now;
                        nudTicketprice.Value = 0;

                        tbCountry.Text = "";
                        tbProvince.Text = "";
                        tbCity.Text = "";
                        tbStreet.Text = "";
                        nudStreetnumber.Value = 0;
                        tbPostalcode.Text = "";

                        MessageBox.Show("No events found");
                    }
                }
                else
                {
                    lblEventIDValue.Text = "";
                    tbName.Text = "";
                    tbDescription.Text = "";
                    dtpStartDate.Value = DateTime.Now;
                    dtpEndDate.Value = DateTime.Now;
                    nudTicketprice.Value = 0;

                    tbCountry.Text = "";
                    tbProvince.Text = "";
                    tbCity.Text = "";
                    tbStreet.Text = "";
                    nudStreetnumber.Value = 0;
                    tbPostalcode.Text = "";

                    MessageBox.Show("No even selected");
                }
            }
            else
            {
                lblEventIDValue.Text = "";
                tbName.Text = "";
                tbDescription.Text = "";
                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now;
                nudTicketprice.Value = 0;

                tbCountry.Text = "";
                tbProvince.Text = "";
                tbCity.Text = "";
                tbStreet.Text = "";
                nudStreetnumber.Value = 0;
                tbPostalcode.Text = "";

                MessageBox.Show("No even selected");
            }
        }
        private void FillDatagridEvents()
        {
            eventControl.GetEvents();

            datagridEvents.Rows.Clear();

            foreach (Event ev in eventControl.Events)
            {
                datagridEvents.Rows.Add(Convert.ToString(ev.EventID), Convert.ToString(ev.Name),
                    Convert.ToString(ev.StartDate), Convert.ToString(ev.EndDate));
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

            if (name != "" && description != "" && startDate >= DateTime.Now && endDate >= DateTime.Now &&
                endDate >= startDate && ticketPrice >= 0 && country != "" && province != "" && city != "" &&
                street != "" && streetnumber > 0 && postalcode.Length == 6)
            {
                if (!eventControl.CheckEvent(name, description, startDate, endDate, ticketPrice))
                {
                    if (!eventControl.CheckAddress(country, province, city, street, streetnumber, postalcode))
                    {
                        eventControl.CreateAddress(country, province, city, street, streetnumber, postalcode);
                    }

                    eventControl.CreateEvent(name, description, startDate, endDate, ticketPrice, eventControl.DbEvent.GetAddressID(country, province, city, street, streetnumber, postalcode));
                    MessageBox.Show("New event has been created");
                }
            }
            else
            {
                if (name == "")
                {
                    MessageBox.Show("The name is invalid");
                }
                if (description == "")
                {
                    MessageBox.Show("The description is invalid");
                }
                if (startDate < DateTime.Now)
                {
                    MessageBox.Show("The startDate is invalid");
                }
                if (endDate < dtpStartDate.Value)
                {
                    MessageBox.Show("The endDate is invalid");
                }
                if (ticketPrice < 0)
                {
                    MessageBox.Show("The ticketPrice is invalid");
                }
                if (country == "")
                {
                    MessageBox.Show("The country is invalid");
                }
                if (province == "")
                {
                    MessageBox.Show("The province is invalid");
                }
                if (city == "")
                {
                    MessageBox.Show("The city is invalid");
                }
                if (street == "")
                {
                    MessageBox.Show("The street is invalid");
                }
                if (streetnumber <= 0)
                {
                    MessageBox.Show("The housenumber is invalid");
                }
                if (postalcode.Length != 6)
                {
                    MessageBox.Show("The postalcode is invalid");
                }
            }
            FillDatagridEvents();
        }

        private void datagridEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshData();
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (eventControl.CheckEvent(tbName.Text, tbDescription.Text, dtpStartDate.Value, dtpEndDate.Value,
                nudTicketprice.Value))
            {
                int eventID = eventControl.GetEvent(tbName.Text, tbDescription.Text, dtpStartDate.Value, dtpEndDate.Value, nudTicketprice.Value).EventID;

                if (eventID != -1)
                {
                    eventControl.DeleteEvent(eventID);
                    MessageBox.Show("Event has been deleted");
                }
                else
                {
                    MessageBox.Show("The event already doesn't exist");
                }
            }

            FillDatagridEvents();
            RefreshData();
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            int eventID = Convert.ToInt32(lblEventIDValue.Text);
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


            if (name != "" && description != "" && startDate >= DateTime.Now && endDate >= DateTime.Now && endDate >= startDate && ticketPrice >= 0 && country != "" && province != "" && city != "" && street != "" && streetnumber > 0 && postalcode.Length == 6)
            {
                if (eventControl.CheckEvent(eventID))
                {
                    Event ev = eventControl.GetEvent(eventID);

                    if (name != ev.Name)
                    {
                        eventControl.EditEvent(ev.EventID, "eventName", name);
                    }
                    if (startDate != ev.StartDate)
                    {
                        eventControl.EditEvent(ev.EventID, "startDate", startDate.ToShortDateString());
                    }
                    if (endDate != ev.EndDate)
                    {
                        eventControl.EditEvent(ev.EventID, "endDate", endDate.ToShortDateString());
                    }
                    if (description != ev.Description)
                    {
                        eventControl.EditEvent(ev.EventID, "description", description);
                    }
                    if (ticketPrice != ev.TicketPrice)
                    {
                        eventControl.EditEvent(ev.EventID, "ticketPrice", ticketPrice);
                    }
                    MessageBox.Show("The event has been edited");
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("The name is invalid");
                    }
                    if (description == "")
                    {
                        MessageBox.Show("The description is invalid");
                    }
                    if (startDate < DateTime.Now)
                    {
                        MessageBox.Show("The startDate is invalid");
                    }
                    if (endDate < startDate)
                    {
                        MessageBox.Show("The endDate is invalid");
                    }
                    if (ticketPrice < 0)
                    {
                        MessageBox.Show("The ticketPrice is invalid");
                    }
                    if (country == "")
                    {
                        MessageBox.Show("The country is invalid");
                    }
                    if (province == "")
                    {
                        MessageBox.Show("The province is invalid");
                    }
                    if (city == "")
                    {
                        MessageBox.Show("The city is invalid");
                    }
                    if (street == "")
                    {
                        MessageBox.Show("The street is invalid");
                    }
                    if (streetnumber <= 0)
                    {
                        MessageBox.Show("The housenumber is invalid");
                    }
                    if (postalcode.Length != 6)
                    {
                        MessageBox.Show("The postalcode is invalid");
                    }

                    eventControl.GetEvents();
                    FillDatagridEvents();
                    RefreshData();
                }
            }
        }
    }
}
