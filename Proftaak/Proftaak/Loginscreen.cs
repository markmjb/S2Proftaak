using System;
using System.Windows.Forms;
using Businesslayer.Business;

namespace Proftaak
{
    public partial class Loginscreen : Form
    {
        private Login login;
        public Loginscreen()
        {
            InitializeComponent();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Loginscreen_Load(object sender, EventArgs e)
        {
            lblWarning.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = new Login();

            bool rightcredentials = login.CheckLogin(tbEmail.Text, tbPassword.Text);
            if (rightcredentials == false)
            {
                lblWarning.Enabled = true;
            }
            else
            {
                this.Hide();
                StartScreen S = new StartScreen();
                S.Show();
                login.Updateuser(tbEmail.Text, tbPassword.Text);

            }
            //Check for correct login, than:

        }
    }
}
