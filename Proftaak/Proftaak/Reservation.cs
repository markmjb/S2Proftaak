using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
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

        private List<Businesslayer.Business.Campspot> Campspots;
        private List<Campspot> Selectedcampspots; 
        private List<Event> Events = new List<Event>();
        private List<Group> groups = new List<Group>(); 
        private ReservationCampspot RC = new ReservationCampspot();
        private List<User> users; 
        private User user = new User();
        private Address address= new Address();
        private Event _event;
        private bool Isloaded = new bool();

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
            users= new List<User>();
            Events = RC.Events();
            cbEvent.DataSource = Events;
            cbEvent.DisplayMember = "Name";
            Campspots = RC.UpdateCampingSpots(((Event) cbEvent.SelectedItem).EventID);
            lbAvailablespots.DataSource = Campspots;
            lbAvailablespots.DisplayMember = "Campplace";
            Updategroups();
            tbPassword.Text = string.Empty;
        }

        private void Updategroups()
        {
            groups = RC.GetAllGroups();
            cbGroup.DataSource = groups;
            cbGroup.DisplayMember = "Name";
        }

        private void UpdateUsers()
        {
            try
            {
                cbAddedusers.ValueMember = "Firstname";
                cbAddedusers.DisplayMember = "Firstname";
                cbAddedusers.DataSource = users;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            


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
            bool nonexttab = new bool();
            nonexttab = false;
            if (tabControl1.SelectedTab == tabEvent)
            {
                _event = (Event) cbEvent.SelectedItem;
            }
            if (tabControl1.SelectedTab==tabCampspot)
            {
                if (lbAvailablespots.SelectedIndex == -1)
                {
                    MessageBox.Show("Select one or more campspots first");
                    nonexttab = true;
                }
                else { 
                foreach (var C in lbAvailablespots.SelectedItems)
                {
                 Selectedcampspots = new List<Campspot>();
                Selectedcampspots.Add((Campspot)C);
                }
                }
            }
            if (tabControl1.SelectedTab == tabAddUser)
            {
                if (cbAddedusers.SelectedIndex == -1)
                {
                    MessageBox.Show("Add one or more users");
                    nonexttab = true;

                }
            }
            if (!nonexttab)
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
                address = new Address(tbStreetnumber.Text, Convert.ToInt32(tbStreetnumber.Text), tbPostalcode.Text,
                      tbCity.Text, tbState.Text, tbCountry.Text);
                user = new User(tbFirstname.Text, tbLastname.Text, address, tbEmail.Text, tbPassword.Text,
                    (Group)cbGroup.SelectedItem,dtpBirth.Value);
            }
            else
            {
                 MessageBox.Show("Please fill in all required fields");          
            }

            users.Add(user);
            UpdateUsers();
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
                Campspots = RC.UpdateCampingSpots(((Event)cbEvent.SelectedItem).EventID);
                lbAvailablespots.DataSource = Campspots;
            }
            else if (cbCSprop.SelectedItem.ToString() == "Show Impaired")
            {
                   Campspots = RC.FilterCampingSpots(((Event) cbEvent.SelectedItem).EventID, "handicap");
                   lbAvailablespots.DataSource = Campspots;       
            }
            else if (cbCSprop.SelectedItem.ToString() == "Show Normal")
            {
                Campspots = RC.FilterCampingSpots(((Event)cbEvent.SelectedItem).EventID, "normaal");
                lbAvailablespots.DataSource = Campspots;
            }
            else if (cbCSprop.SelectedItem.ToString() =="Show Quiet")   
                {
                  Campspots = RC.FilterCampingSpots(((Event) cbEvent.SelectedItem).EventID, "rustig");
                  lbAvailablespots.DataSource = Campspots;
                }
               
            }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (tbNewGroup.Text!=string.Empty)
            { 
         bool Groupexists = RC.CheckGroup(tbNewGroup.Text);
            if (Groupexists)
            {
                MessageBox.Show("Group already exists");
            }
            else
            {
                RC.CreateGroup(tbNewGroup.Text);
            }
        
        }
            else
            {
                MessageBox.Show("Fill In A Groupname");
            }
            tbNewGroup.Text = string.Empty;
            Updategroups();
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
                    user = new User();
                    user = (User) cbAddedusers.SelectedItem;
                    tbFirstname.Text = user.Firstname;
                    tbLastname.Text = user.Lastname;
                    tbStreet.Text = user.Address.Street;
                    tbStreetnumber.Text = user.Address.Streetnumber.ToString();
                    tbPostalcode.Text = user.Address.PostalCode;
                    tbCity.Text = user.Address.City;
                    tbState.Text = user.Address.Province;
                    tbCountry.Text = user.Address.Country;
                    dtpBirth.Value = user.Birthdate;
                    tbEmail.Text = user.Email;
                    tbPassword.Text = user.Password;
                    cbGroup.SelectedItem = user.Group;
                    Isloaded = true;
                }
                else
                {
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
            
            RC.SaveReservation(users,Selectedcampspots,_event);
        }
        
        }
    }
