using System;
using System.Windows.Forms;
using Businesslayer.Business;

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
            Reservation reservation = new Reservation();
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

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (tbOldpass.Text == string.Empty || tbNewpass2.Text == string.Empty || tbNewpass2.Text == string.Empty ||
                tbNewpass1.Text != tbNewpass2.Text || tbOldpass.Text != Userlogin.Loggeduser.Password)
            {
                MessageBox.Show("Invalid Fields");
            }
            else
            {
                Login L = new Login();
                L.Changepass(tbNewpass1.Text);
                L.Updateuser(Userlogin.Loggeduser.Email, tbNewpass1.Text);
                MessageBox.Show(Userlogin.Loggeduser.Password);
            }
        }
    }
}
