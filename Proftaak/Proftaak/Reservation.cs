using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Businesslayer;
using Businesslayer.Business;

namespace Proftaak
{
    public partial class Reservation : Form
    {
        
            List<int> Availablespots=new List<int>();
            List<int> Selectedspots= new List<int>();
            ReservationCampspot RC = new ReservationCampspot();
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
        
            foreach (int I in Availablespots)
            {
                lbAvailablespots.Items.Add(Convert.ToString(I));
            }
        }

        private void Updatespots()
        {
            Availablespots = RC.UpdateCampingSpots();

        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                
            }
            else
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
               
            }
            else
            {
                tabControl1.SelectedIndex++;
            }
        }


        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbAvailablespots.SelectedIndex == -1)
            {
                MessageBox.Show("Select A Campingspot");
            }
            else
            {
                lbselectedcampspots.Items.Add(lbAvailablespots.SelectedItem);
                lbAvailablespots.Items.Remove(lbAvailablespots.SelectedItem);
            }
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            if (lbselectedcampspots.SelectedIndex == -1)
            {
                MessageBox.Show("Select A Campingspot");
            }
            else
            {
                lbAvailablespots.Items.Add(lbAvailablespots.SelectedItem);
                lbselectedcampspots.Items.Remove(lbAvailablespots.SelectedItem);
            }

        }
        }
}
