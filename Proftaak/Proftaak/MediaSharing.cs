﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class Mediasharing : Form
    {
        public Mediasharing()
        {
            InitializeComponent();
        }



        private void Mediasharing_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        private void btnUploadMedia_Click(object sender, EventArgs e)
        {

        }
    }
}
