using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using Businesslayer;
using Businesslayer.Business;

namespace Proftaak
{
    public partial class MaterialControlForm : Form
    {
        
        private RFID rfid;
        private string TempRFID;
        User ScannedUser;

        Itembusiness IB = new Itembusiness();
        List<Item> items;
        List<Event> Events;

        private int totalprice;

        public MaterialControlForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            cbEvents.SelectedIndex = 0;
        }

        void LoadComboBoxes()
        {
            items = IB.GetItems();
            Events = IB.GetEvents();

            foreach (Event E in Events)
            {
                cbEvents.Items.Add(E.Name);
            }

            foreach (Item I in items)
            {
                cbItem.Items.Add(I.Name);
                cbItemStock.Items.Add(I.Name + " , €" + I.Price);
                lbSelectItem.Items.Add(I.Name + " , €" + I.Price);
                lbItems.Items.Add("Product : " + I.Name + " , prijs: €" + I.Price);
            }
        }

        private void MaterialControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         StartScreen S = new StartScreen();
            S.Show();

            rfid.Attach -= new AttachEventHandler(rfid_Attach);
            rfid.Detach -= new DetachEventHandler(rfid_Detach);
            rfid.Tag -= new TagEventHandler(rfid_Tag);
            rfid.TagLost -= new TagEventHandler(rfid_TagLost);
            rfid.close();
        }
        private void MaterialControlForm_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.TagLost += new TagEventHandler(rfid_TagLost);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            openCmdLine(rfid);
            Update();
        }
        void rfid_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;
            lblRFIDreader.Text = e.Device.Attached.ToString();
            rfid.Antenna = true;

            switch (attached.ID)
            {
                case Phidget.PhidgetID.RFID_2OUTPUT_READ_WRITE:
                    break;
                case Phidget.PhidgetID.RFID:
                case Phidget.PhidgetID.RFID_2OUTPUT:
                default:
                    break;
            }
        }
        void rfid_Tag(object sender, TagEventArgs e)
        {
            lbRFIDNr.Text = e.Tag;
            TempRFID = e.Tag;
        }
        void rfid_TagLost(object sender, TagEventArgs e)
        {
            lbRFIDNr.Text = "";
        }
        void rfid_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;
            lblRFIDreader.Text = e.Device.Attached.ToString();
        }
        //Parses command line arguments and calls the appropriate open
        #region Command line open functions
        private void openCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }
        private void openCmdLine(Phidget p, String pass)
        {
            int serial = -1;
            String logFile = null;
            int port = 5001;
            String host = null;
            bool remote = false, remoteIP = false;
            string[] args = Environment.GetCommandLineArgs();
            String appName = args[0];

            try
            { //Parse the flags
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "l":
                                logFile = (args[++i]);
                                break;
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIP = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }
                                break;
                            default:
                                goto usage;
                        }
                    else
                        goto usage;
                }
                if (logFile != null)
                    Phidget.enableLogging(Phidget.LogLevel.PHIDGET_LOG_INFO, logFile);
                if (remoteIP)
                    p.open(serial, host, port, pass);
                else if (remote)
                    p.open(serial, host, pass);
                else
                    p.open(serial);
                return; //success
            }
            catch { }
        usage:
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-l   logFile\tEnable phidget21 logging to logFile.");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
        #endregion

        private void btnChange_Click(object sender, EventArgs e)
        {            
            IB.ChangePrice(cbItem.SelectedItem.ToString(), Convert.ToInt32(tbPrice.Text));
            Update();
        }
        private new void Update()
        {
            lbItems.Items.Clear();
            lbSelectItem.Items.Clear();
            items = IB.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                lbItems.Items.Add("Product : " + items[i].Name + " , prijs: €" + items[i].Price);
                lbSelectItem.Items.Add(items[i].Name + " , €" + items[i].Price);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IB.AddStock(cbItemStock.SelectedItem.ToString(), Convert.ToInt32(tbPrice.Text));
            Update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(nudAmount.Value == 0)
            {
                MessageBox.Show("Aantal mag geen 0 zijn!");
            }
            else
            {
                lbYourItem.Items.Add(lbSelectItem.SelectedItem.ToString() + ", " + nudAmount.Value.ToString() + " x");
                UpdateTotalPrice();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lbYourItem.Items.Remove(lbYourItem.SelectedItem);
            UpdateTotalPrice();
        }

        private void button3_Click(object sender, EventArgs e)  
        {
            UpdateTotalPrice();
            totalprice = Convert.ToInt32(ScannedUser.Debt) + totalprice;
            Event SelEv = Events.ElementAt(cbEvents.SelectedIndex);
            IB.GiveUserDebt(ScannedUser.ID, SelEv.EventID, totalprice);    
        }
        public void UpdateTotalPrice()
        {
            totalprice = 0;
            int price;
            int tempprice = 0;
            for (int i = 0;  i < lbYourItem.Items.Count; i++)          
            {
                string naam;              
                int found = 0;
                int found2 = 0;
                string substring;
                string substring2;
                naam = lbYourItem.Items[i].ToString();
                found = naam.IndexOf(",");
                found2 = naam.IndexOf("x");
                substring = naam.Substring(0, found - 1);
                substring2 = naam.Substring(found2 - 2, 1);
                for (int j = 0; j < Convert.ToInt32(substring2); j++)
                {
                    price = IB.UpdateTotalPrice(substring);
                    tempprice = price + tempprice;
                }
            }
            totalprice = tempprice + totalprice;
            lblTotalPrice.Text = Convert.ToString(totalprice);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void ReturnMaterial()
        {
            //IB.ReturnMaterial();
        }
        public void GetReservedItems()
        {

        }

        private void lbRFIDNr_TextChanged(object sender, EventArgs e)
        {
            ScannedUser = IB.RFIDuser(TempRFID);
            if (ScannedUser != null )
            {
                label7.Text = ScannedUser.Lastname + ", " + ScannedUser.Firstname;
                label8.Text = Convert.ToString(ScannedUser.ReservationID);
                label38.Text = ScannedUser.Lastname + ", " + ScannedUser.Firstname;
                label37.Text = Convert.ToString(ScannedUser.ReservationID);
            }
            else
            {
                label7.Text = "";
                label8.Text = "";
                label38.Text = "";
                label37.Text = "";
            }
        }
    }
}
