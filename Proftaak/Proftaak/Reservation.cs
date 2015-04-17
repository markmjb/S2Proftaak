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
        ReservationCampspot RC=new ReservationCampspot();
            RC.UpdateCampingSpots();
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
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            if (lbselectedcampspots.SelectedIndex == -1)
            {
                MessageBox.Show("Select A Campingspot");
            }

        }


    }
}
