using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            this.Hide();
        Reservation reservation= new Reservation();
            reservation.Show();
        }

        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
        Loginscreen L = new Loginscreen();
            L.Show();
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            this.Hide();
        MaterialControlForm M = new MaterialControlForm();
            M.Show();
        }

        private void btnAccessControl_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccessControlForm A = new AccessControlForm();
            A.Show();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventControl E = new EventControl();
            E.Show();
        }

        private void btnMediaSharing_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mediasharing M = new Mediasharing();
            M.Show();
        }

    }
}
