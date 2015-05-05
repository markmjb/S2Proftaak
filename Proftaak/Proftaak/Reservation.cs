using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Businesslayer;
using Businesslayer.Business;
using Businesslayer.DAL;

namespace Proftaak
{
    public partial class Reservation : Form
    {

        private IList<Campspot> campspots = new List<Campspot>();
        private IList<Campspot> selectedcampspots = new List<Campspot>();
        private IList<Event> events = new List<Event>();
        private IList<Group> groups = new List<Group>();
        private IList<User> users = new List<User>();
        private ReservationCampspot RC;
        private User _user;
        private Address _address;
        private Event _event;
        private bool Isloaded;

        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            RC = new ReservationCampspot();
            users = new BindingList<User>();
            events = RC.Events();
            groups = RC.GetAllGroups();
            cbGroup.DataSource = groups;
            cbGroup.DisplayMember = "Name";
            cbAddedusers.DataSource = users;
            cbAddedusers.DisplayMember = "Firstname";
            cbEvent.DataSource = events;
            cbEvent.DisplayMember = "Name";
            lbAvailablespots.DataSource = campspots;
            lbAvailablespots.DisplayMember = "Campplace";
            campspots = RC.UpdateCampingSpots(((Event)cbEvent.SelectedItem).EventID);
            _user = new User();
            _address = new Address();
            _event = new Event();
        }

       private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex!=tabControl1.TabCount)
            {
                tabControl1.SelectedIndex++;
            }
        }



        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            if (tbFirstname.Text != string.Empty && tbLastname.Text != string.Empty && tbEmail.Text != string.Empty &&
                tbPostalcode.Text != string.Empty && tbStreet.Text != string.Empty &&
                tbStreetnumber.Text != string.Empty && tbCountry.Text != string.Empty && tbState.Text != string.Empty &&
                cbGroup.SelectedIndex != -1)
            {
                _address = new Address(tbStreetnumber.Text, Convert.ToInt32(tbStreetnumber.Text), tbPostalcode.Text,
                      tbCity.Text, tbState.Text, tbCountry.Text);
                _user = new User(tbFirstname.Text, tbLastname.Text, _address, tbEmail.Text, tbPassword.Text,
                    (Group)cbGroup.SelectedItem,dtpBirth.Value);
            }
            else
            {
                 MessageBox.Show("Please fill in all required fields");          
            }

            users.Add(_user);
            
            ClearallFields();
        }
     
        private void ClearallFields()
        {
            tbFirstname.Text = string.Empty;
            tbLastname.Text = string.Empty;
            tbStreet.Text = string.Empty;
            tbStreetnumber.Text = string.Empty;
            tbPostalcode.Text = string.Empty;
            tbCity.Text = string.Empty;
            tbState.Text = string.Empty;
            tbCountry.Text = string.Empty;
            dtpBirth.Value = DateTime.Now;
            tbNewGroup.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPassword.Text = string.Empty;
            cbAddedusers.DataSource = users;
        }

        private void cbCSprop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCSprop.SelectedItem.ToString()  == "Show All")
            {
                campspots = RC.UpdateCampingSpots(((Event)cbEvent.SelectedItem).EventID);
                lbAvailablespots.DataSource = campspots;
            }
            else if (cbCSprop.SelectedItem.ToString() == "Show Impaired")
            {
                   campspots = RC.FilterCampingSpots(((Event) cbEvent.SelectedItem).EventID, "handicap");
                   lbAvailablespots.DataSource = campspots;       
            }
            else if (cbCSprop.SelectedItem.ToString() == "Show Normal")
            {
                campspots = RC.FilterCampingSpots(((Event)cbEvent.SelectedItem).EventID, "normaal");
                lbAvailablespots.DataSource = campspots;
            }
            else if (cbCSprop.SelectedItem.ToString() =="Show Quiet")   
                {
                  campspots = RC.FilterCampingSpots(((Event) cbEvent.SelectedItem).EventID, "rustig");
                  lbAvailablespots.DataSource = campspots;
                }
               
            }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (tbNewGroup.Text!=string.Empty)
            { 
            if (this.RC.CheckGroup(this.tbNewGroup.Text))
                {
                    MessageBox.Show("Group already exists");
                }
            else
                {
                    this.RC.CreateGroup(this.tbNewGroup.Text);
                }
        
            }
            else
            {
                MessageBox.Show("Fill In A Groupname");
            }
            tbNewGroup.Text = string.Empty;
            groups = RC.GetAllGroups();
            cbGroup.DataSource = groups;

        }

        private void btnLoadUser_Click(object sender, EventArgs e)
        {
            
            if (cbAddedusers.SelectedIndex == -1)
            {
                MessageBox.Show("Select a User");
            }
            else
            {
                if (!Isloaded)
                {
                    _user = new User();
                    _user = (User) cbAddedusers.SelectedItem;
                    tbFirstname.Text = _user.Firstname;
                    tbLastname.Text = _user.Lastname;
                    tbStreet.Text = _user.Address.Street;
                    tbStreetnumber.Text = _user.Address.Streetnumber.ToString();
                    tbPostalcode.Text = _user.Address.PostalCode;
                    tbCity.Text = _user.Address.City;
                    tbState.Text = _user.Address.Province;
                    tbCountry.Text = _user.Address.Country;
                    dtpBirth.Value = _user.Birthdate;
                    tbEmail.Text = _user.Email;
                    tbPassword.Text = _user.Password;
                    cbGroup.SelectedItem = _user.Group;
                    Isloaded = true;
                }
                else
                {
                    if (tbFirstname.Text != string.Empty && tbLastname.Text != string.Empty && tbEmail.Text != string.Empty &&
                    tbPostalcode.Text != string.Empty && tbStreet.Text != string.Empty &&
                    tbStreetnumber.Text != string.Empty && tbCountry.Text != string.Empty && tbState.Text != string.Empty &&
                    cbGroup.SelectedIndex != -1)
                    {
                        _address = new Address(tbStreetnumber.Text, Convert.ToInt32(tbStreetnumber.Text), tbPostalcode.Text,
                              tbCity.Text, tbState.Text, tbCountry.Text);
                        _user = new User(tbFirstname.Text, tbLastname.Text, _address, tbEmail.Text, tbPassword.Text,
                            (Group)cbGroup.SelectedItem, dtpBirth.Value);
                        if (_user != (User) cbAddedusers.SelectedItem)
                        {
                            users.Remove((User) cbAddedusers.SelectedItem);
                            users.Add(_user);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all required fields or cancel the edit");
                    }
                ClearallFields();
                    Isloaded = false;
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbAddedusers.SelectedIndex != -1)
            {
                users.Remove((User)cbAddedusers.SelectedItem);
            }
        }

        private void btnFinishReservation_Click(object sender, EventArgs e)
        {
            foreach (Campspot S in lbAvailablespots.SelectedItems)
            {
            selectedcampspots.Add(S);

            }
            if (DisplayError())
            {
                _event = (Event) cbEvent.SelectedItem;
            RC.SaveReservation(users,selectedcampspots,_event);
            foreach (User U in users)
            {
            SendEmails(U);
            }
            this.Hide();
            StartScreen S = new StartScreen();
            S.Show();
                }
        }

        private bool DisplayError()
        {
            int haserror = 1;
             string errorstring = string.Empty;
            List<string> errorstringlist = new List<string>();
            if (cbEvent.SelectedIndex == -1)
            {
                errorstring = "You haven't selected an event\n";
                errorstringlist.Add(errorstring);
                haserror--;
            }
            else
            {
                errorstring="You have selected an event\n";
                errorstringlist.Add(errorstring);
                if (cbAddedusers.SelectedIndex == -1)
                {
                    errorstring = "You haven't selected any users\n";
                    errorstringlist.Add(errorstring);
                    haserror--;
                }
                else
                {
                    errorstring = "You have selected one or more users\n";
                    errorstringlist.Add(errorstring);
                }
                if (lbAvailablespots.SelectedIndex == -1)
                    {
                        errorstring = "You haven't selected any campingspots to camp on\n";
                        errorstringlist.Add(errorstring);
                        haserror--;
                    }
                    else
                    {
                        errorstring = "You have selected one or more campingspots\n";
                        errorstringlist.Add(errorstring);
                    }
                }
            
            errorstring = errorstringlist.Aggregate(string.Empty, (current, s) => current + s);
            MessageBox.Show(errorstring);
            return haserror == 1;
        }

        private void SendEmails(User user)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("proftaakgroepA@gmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "Camping registratie";
                string sql = string.Format("Welkom op de camping! \n\n Hier is uw (tijdelijke) wachtwoord: {0}\n"
                                           +
                                           "Log hiermee in op de portal \n\n Uw Reserveringsnummer is : {1} Met vriendelijke groet, \n\n De Camping",
                    user.Password, user.ReservationID);
                mail.Body = sql;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(@"proftaakgroepA@gmail.com", "Proftaak_19");

                // Email, Password
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        }
    }
