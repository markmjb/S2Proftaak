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
    public partial class MaterialControlForm : Form
    {
        public MaterialControlForm()
        {
            InitializeComponent();
        }

        private void MaterialControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         StartScreen S = new StartScreen();
            S.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}