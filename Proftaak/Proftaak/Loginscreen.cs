﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Businesslayer;
using Businesslayer.Business;

namespace Proftaak
{
    public partial class Loginscreen : Form
    {
        public Loginscreen()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Loginscreen_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            bool rightcredentials = login.CheckLogin(tbEmail.Text, tbPassword.Text);
            if (rightcredentials==false)
            {

            }
            else
            {
                this.Hide();
                StartScreen S = new StartScreen();
                S.Show();
                Userlogin.UpdateUser(tbEmail.Text, tbPassword.Text);
            }
            //Check for correct login, than:

        }
    }
}
