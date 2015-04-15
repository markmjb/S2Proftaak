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
using Businesslayer.Business;

namespace Proftaak
{
    public partial class EventControl : Form
    {
        //FIELDS
        private Businesslayer.Business.EventControl eventControl = new Businesslayer.Business.EventControl();
        
        //CONSTRUCTORS
        public EventControl()
        {
            InitializeComponent();

            FillDatagridEvents();
        }
        //EVENTS
        private void EventControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        //METHODS
        private void FillDatagridEvents()
        {
            datagridEvents.Rows.Clear();

            foreach (Event ev in eventControl.Events)
            {
                datagridEvents.Rows.Add(Convert.ToString(ev.EventID), Convert.ToString(ev.Name), Convert.ToString(ev.StartDate), Convert.ToString(ev.EndDate));
            }
        }
    }
}
