using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Businesslayer;
using Businesslayer.Business;
using Businesslayer.DAL;

namespace Proftaak
{
    public partial class Reservation : Form
    {

        private List<Businesslayer.Business.Campspot> Campspots;
        private List<Event> Events = new List<Event>();
        private List<Group> groups = new List<Group>(); 
        private ReservationCampspot RC = new ReservationCampspot();

        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            Events = RC.Events();
            cbEvent.DataSource = Events;
            cbEvent.DisplayMember = "Name";
            Campspots = RC.UpdateCampingSpots(((Event) cbEvent.SelectedItem).EventID);
            lbAvailablespots.DataSource = Campspots;
            lbAvailablespots.DisplayMember = "Campplace";
            groups = RC.GetAllGroups();
            cbGroup.DataSource = groups;
            cbGroup.DisplayMember = "Name";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 3)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {



        }

        private void cbCSprop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCSprop.SelectedItem.ToString()  == "Show All")
            {
                Campspots = RC.UpdateCampingSpots(((Event)cbEvent.SelectedItem).EventID);
                lbAvailablespots.DataSource = Campspots;
            }
            else if (cbCSprop.SelectedItem.ToString() == "Show Impaired")
            {
                   Campspots = RC.FilterCampingSpots(((Event) cbEvent.SelectedItem).EventID, "handicap");
                   lbAvailablespots.DataSource = Campspots;       
            }
            else if (cbCSprop.SelectedItem.ToString() == "Show Normal")
            {
                Campspots = RC.FilterCampingSpots(((Event)cbEvent.SelectedItem).EventID, "normaal");
                lbAvailablespots.DataSource = Campspots;
            }
            else if (cbCSprop.SelectedItem.ToString() =="Show Quiet")   
                {
                  Campspots = RC.FilterCampingSpots(((Event) cbEvent.SelectedItem).EventID, "rustig");
                  lbAvailablespots.DataSource = Campspots;
                }
               
            }
        }
    }

