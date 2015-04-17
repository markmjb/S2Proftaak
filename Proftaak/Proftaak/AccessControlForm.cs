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
    public partial class AccessControlForm : Form
    {
        private RFID rfid;
        private int SelectedReservation;
        private string TempRFID;

        AccessControl AC = new AccessControl();
        List<ReservationAccess> Reservations;
        List<ReservationAccess> SearchResults;
        List<User> ReservationUsers;
        List<User> EventUsers;
        List<Event> AllEvents;

        public AccessControlForm()
        {
            InitializeComponent();
        }

        private void AccessControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();

            rfid.Attach -= new AttachEventHandler(rfid_Attach);
            rfid.Detach -= new DetachEventHandler(rfid_Detach);
            rfid.Tag -= new TagEventHandler(rfid_Tag);
            rfid.TagLost -= new TagEventHandler(rfid_TagLost);
            rfid.close();
        }

        private void AccessControlForm_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.TagLost += new TagEventHandler(rfid_TagLost);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            openCmdLine(rfid);

            LoadCBoxEvents();
        }
        void rfid_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;
            label2.Text = e.Device.Attached.ToString();

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
            label3.Text = e.Tag;
            TempRFID = e.Tag;
        }
        void rfid_TagLost(object sender, TagEventArgs e)
        {
            label3.Text = "";
        }
        void rfid_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;
            label3.Text = detached.Attached.ToString();
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

        void LoadReservationListBox()
        {
            lbResNr.Items.Clear();
            AllEvents = AC.GetEvents();

            if (cbEvent.SelectedIndex != -1)
            {
                int SelectedEvent = cbEvent.SelectedIndex;
                Event SelEvent = AllEvents.ElementAt(SelectedEvent);
                Reservations = AC.GetAllReservations(SelEvent.EventID);

                foreach (ReservationAccess R in Reservations)
                {
                    lbResNr.Items.Add(R.ReservationNr + "\t|\t" + R.Payment);
                }
            }
        }
        void LoadReservationUserListBox()
        {
            lbResName.Items.Clear();
            if (SelectedReservation != -1)
            {
                ReservationUsers = AC.GetUserInfo(SelectedReservation);

                foreach (User U in ReservationUsers)
                {
                    lbResName.Items.Add(U.ReservationID + "  |  " + U.Lastname + "," + U.Firstname);
                }
            }
        }
        void LoadCBoxEvents()
        {
            cbEvent.Items.Clear();
            AllEvents = AC.GetEvents();
            foreach (Event E in AllEvents)
            {
                cbEvent.Items.Add(E.Name);
            }
        }
        void LoadPresentList()
        {
            if (cbEvent.SelectedIndex != -1)
            {
                int SelectedEvent = cbEvent.SelectedIndex;
                Event SelEvent = AllEvents.ElementAt(SelectedEvent);
                EventUsers = AC.GetAllUsers(SelEvent.EventID);

                foreach (User R in EventUsers)
                {
                    if(R.IsPresent)
                    {
                        lbPresentList.Items.Add("Reservation: " + R.ReservationID + " Name: " + R.Lastname + "," + R.Firstname + " Presents: " + R.IsPresent);
                    }
                }
            }
        }

        private void btnDelRes_Click(object sender, EventArgs e)
        {
            AC.DeleteReservation(Convert.ToInt32(tbDelRes.Text));
            LoadReservationListBox();
        }

        private void btnPaym_Click(object sender, EventArgs e)
        {
            AC.AcceptPay((Convert.ToInt32(tbDelRes.Text)));
            LoadReservationListBox();
        }

        private void cbEvent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbResName.Items.Clear();
            LoadReservationListBox();
            LoadPresentList();

            if (lbResNr.SelectedIndex == -1)
            {
                lbResName.Items.Clear();
            }
        }

        private void lbResNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = lbResNr.SelectedIndex;
            ReservationAccess R = Reservations.ElementAt(SelectedIndex);
            SelectedReservation = R.ReservationNr;
            LoadReservationUserListBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbResNr.Items.Clear();
            AllEvents = AC.GetEvents();

            if (cbEvent.SelectedIndex != -1)
            {
                int SelectedEvent = cbEvent.SelectedIndex;
                Event SelEvent = AllEvents.ElementAt(SelectedEvent);
                Reservations = AC.GetAllReservations(SelEvent.EventID);

                lbResNr.Items.Clear();
                SearchResults = AC.Search(SelEvent.EventID, (Convert.ToInt32(tbSearch.Text)));
                foreach (ReservationAccess R in Reservations)
                {
                    lbResNr.Items.Add(R.ReservationNr + "\t|\t" + R.Payment);
                }
            }
        }

        private void lbResName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = lbResName.SelectedIndex;

            if ( SelectedIndex != -1)
            {
                User U = ReservationUsers.ElementAt(SelectedIndex);
                bool isPresent = AC.getPresents(U.ID);

                if (U != null)
                {
                    tbSurname.Text = U.Lastname;
                    tbName.Text = U.Firstname;
                    tbGrpName.Text = U.Group.Name;
                    tbEmail.Text = U.Email;
                    tbStrNr.Text = U.Address.Street + " " + Convert.ToString(U.Address.Streetnumber);
                    tbReserv.Text = Convert.ToString(U.ReservationID);
                    tbPstlCode.Text = U.Address.PostalCode;
                    tbCity.Text = U.Address.City;
                    tbArrival.Text = U.StartDate.ToString();
                    tbDepature.Text = U.EndDate.ToString();
                    if (isPresent)
                    {
                        pbChecked.BackColor = Color.Green;
                    }
                    else
                    {
                        pbChecked.BackColor = Color.Red;
                    }
                }
            }
        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            int SelectedIndex = lbResName.SelectedIndex;

            if (SelectedIndex != -1)
            {
                User U = ReservationUsers.ElementAt(SelectedIndex);
                bool isAttached = AC.getUserRFID(U.ID);

                if (cbEvent.SelectedIndex != -1 && isAttached == false)
                {
                    int SelectedEvent = cbEvent.SelectedIndex;
                    Event SelEvent = AllEvents.ElementAt(SelectedEvent);
                    AC.AttachRFID(U.ID, SelEvent.EventID, TempRFID);
                }
            }
        }

        private void btnUnAtt_Click(object sender, EventArgs e)
        {
            if (cbEvent.SelectedIndex != -1)
            {
                int SelectedEvent = cbEvent.SelectedIndex;
                Event SelEvent = AllEvents.ElementAt(SelectedEvent);
                AC.DettachRFID(SelEvent.EventID, TempRFID);
            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            if (TempRFID != "")
            {
                bool isAttached = AC.getRFID(TempRFID);

                if (isAttached)
                {
                    btnAtt.Enabled = false;
                    btnUnAtt.Enabled = true;
                }
                else if (!isAttached)
                {
                    btnUnAtt.Enabled = true;
                    btnAtt.Enabled = false;
                }
            }
        }
    }
}

