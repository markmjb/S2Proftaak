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
            //Businesslayer.Reservation Res = new Businesslayer.ReservationCampspot()
        }
    }
}
