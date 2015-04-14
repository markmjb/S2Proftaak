using System;
using Businesslayer;
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
    public partial class EventControl : Form
    {
        //CONSTRUCTORS
        public EventControl()
        {
            InitializeComponent();

            Businesslayer.EventControl eventControl = new Businesslayer.EventControl();
        }

        private void EventControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        //METHODS
        public void GetEvents()
        {
            
        }
    }
}
