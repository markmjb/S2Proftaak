using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Windows.Forms;
using Businesslayer;
using System.IO;
using Businesslayer.Business;


namespace Proftaak
{
    public partial class Mediasharing : Form
    {
        private Mediasharingbusiness mdsb = new Mediasharingbusiness();

        public Mediasharing()
        {
            InitializeComponent();
            RefreshFilebox();
            Refresh();


        }

        private int selectedindex;
        private string type;
        private string description;
        private string category;
        private string filepath;
        private string title;
        private string filetype;
        private int size;
        private int userID = Userlogin.Loggeduser.ID;
        private int categoryID;
        private int likes;
        private int likesreply;
        public List<Mediaitem> Mediaitems = new List<Mediaitem>();
        public List<Mediaitem> Mediatext = new List<Mediaitem>();
        public List<Report> Reports = new List<Report>();
        public List<string> Categories = new List<string>(); 

        private void Mediasharing_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartScreen S = new StartScreen();
            S.Show();
        }

        private void btnUploadMedia_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbSelectFile.Text = openFileDialog1.FileName;
            FileInfo F = new FileInfo(openFileDialog1.FileName);
            size = Convert.ToInt32(F.Length/1000);
            filetype = F.Extension;



        }

        private void RefreshReportList()
        {
            listBox2.Items.Clear();
            Reports = mdsb.Getallreports();
            foreach (Report report in Reports)
            {
                listBox2.Items.Add("ReportID: " + report.ReportedID + " MediaitemID of reported file: " +
                                   report.MediaitemID + " Reported by User: " + report.UserID);
            }
        }

        private void btnUploadMediaTab2_Click(object sender, EventArgs e)
        {
            try
            {
                type = cbtypetab2.Text;
                title = tbTitle.Text;
                description = tbDescription.Text;
                filepath = tbSelectFile.Text;
                category = cbCategory.Text;
                categoryID = 3;
                userID = Userlogin.Loggeduser.ID;




                int mediaitemID = mdsb.GetmediaitemID(title);
                Mediaitems = mdsb.Getallmediaitems();
                FileInfo f = new FileInfo(filepath);
                string uploadloc = @"C:\Users\nickbijmoer\Pictures\Server" + "/" + f.Name;
                System.IO.File.Copy(filepath, uploadloc, false);
                MessageBox.Show("File uploaded: " + f.Name);
                this.Close();
                Mediaitem newmedia = new Mediaitem(type, title, description, filepath, categoryID, userID, size,
                    filetype);
            }
            catch (SystemException exc)
            {
                MessageBox.Show("Error moving file:" + exc.Message);
            }
            finally
            {
                Refresh();
                RefreshFilebox();

            }







        }

        public int getcategory()
        {
            categoryID = mdsb.getcategory(category);
            return categoryID;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public new void Refresh()
        {

       

            listBox1.Items.Clear();
            Mediaitems = mdsb.Getallmediaitems();
            
            foreach (Mediaitem mediatext in Mediatext)
            {
                likesreply = mdsb.GetAllLikesReply(mediatext.Mediaitemid);

                listBox1.Items.Add("Reply ID:" + mediatext.Mediaitemid + " Description: " + mediatext.Text + " Likes: " +
                                   likesreply);
            }
        }

        public void RefreshFilebox()
        {
            mdsb.Getallmediaitems();
            Mediaitems = mdsb.Getallmediaitems();

            FileBox.Items.Clear();
            foreach (Mediaitem mediaitem in Mediaitems)
            {
                FileBox.Items.Add(mediaitem.ToString());

            }

        }

        public void RefreshListbox()
        {
            
        }

        private void btnDeleteMedia_Click(object sender, EventArgs e)
        {

            try
            {
                if (FileBox.SelectedIndex == -1)
                {
                    MessageBox.Show("geen item geselecteerd");
                }
                else
                {

                    string selecteditem = FileBox.SelectedItem.ToString();
                    string[] selecteditems = selecteditem.Split(':');
                    selecteditem = selecteditems[1];
                    Mediaitem item = Mediaitems.Find(x => x.Title == selecteditem);
                    int selectedid = Convert.ToInt32(selecteditems[0]);
                    Mediaitem itemfile = mdsb.Getsinglemediaitemfile(selectedid);


                    System.IO.File.Delete(itemfile.Filepath);
                    mdsb.RemoveMediaItem(item);
                    mdsb.RemoveMediaItemFile(item);


                }
                Refresh();
                RefreshFilebox();
                RefreshListbox();
            }
            catch (System.IO.FileNotFoundException)
            {
                {
                    throw;
                }

            }


            Refresh();







        }

        private void FileBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FileBox.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een file");
            }
            else
            {
                tbfileinfo.Clear();

                string selecteditem = FileBox.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':');
                int selecteditemid = Convert.ToInt32(selecteditems[0]);
                Mediaitem itemfile = mdsb.Getsinglemediaitemfile(selecteditemid);
                Mediaitem selected = mdsb.Getsinglemediaitem(selecteditemid);
                string itemfiletype = itemfile.Filetype;
                int itemfilesize = itemfile.Filesize;
                string postedby = Userlogin.Loggeduser.Firstname + " " + Userlogin.Loggeduser.Lastname;
                Mediatext = mdsb.Getmediatextlist(selecteditemid);
                likes = mdsb.GetAllLikes(selecteditemid);
                tbfileinfo.Text = "MediaitemID: " + selected.Mediaitemid + "  Title: " + selected.Title +
                                  "\r\nDescription: " + selected.Description + "\r\nPosted by: " + postedby +
                                  "\r\nFiletype: " + itemfiletype + " Filesize: " + itemfilesize + "KB" + " \r\nLikes: " +
                                  likes;

                selectedindex = 0;


                Mediaitems = mdsb.AlreadyLiked();

                foreach (Mediaitem items in Mediaitems)
                {

                    if (items.UserID == userID && items.Mediaitemid == selecteditemid)
                    {
                        btnLike.Text = "Unlike";

                    }
                    else
                    {
                        btnLike.Text = "Like";
                    }
                }

            }
            Refresh();


        }



        private void cbtypetab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtypetab2.SelectedItem.ToString() == "Text")
            {
                tbSelectFile.Enabled = false;
                btnBrowse.Enabled = false;
            }
            else
            {
                tbSelectFile.Enabled = true;
                btnBrowse.Enabled = true;
            }

            cbCategory.Items.Clear();
            Categories = mdsb.GetAllCategories();
            foreach (string categorie in Categories)
            {
                cbCategory.Items.Add(categorie);
            }
            
        }

        private void btnDownloadMedia_Click(object sender, EventArgs e)
        {
            if (FileBox.SelectedIndex == -1)
            {
                MessageBox.Show("geen item geselecteerd");
            }
            else
            {
                string selecteditem = FileBox.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':');
                int selecteditemid = Convert.ToInt32(selecteditems[0]);
                Mediaitem itemfile = mdsb.Getsinglemediaitemfile(selecteditemid);
                string filepath = itemfile.Filepath;


                FileInfo f = new FileInfo(filepath);

                string uploadloc = @"C:\Users\nickbijmoer\Pictures\Server" + "/" + f.Name;

                try
                {
                    System.IO.File.Copy(uploadloc, filepath, false);
                    MessageBox.Show("File uploaded: " + f.Name);
                    this.Close();
                }
                catch (SystemException exc)
                {
                    MessageBox.Show("Error moving file:" + exc.Message);
                }
            }
        }



        private void btnLike_Click(object sender, EventArgs e)
        {

            if (FileBox.SelectedIndex != -1 && listBox1.SelectedIndex == -1)
            {
                if (btnLike.Text == "Unlike")
                {
                    string selecteditem = FileBox.SelectedItem.ToString();
                    string[] selecteditems = selecteditem.Split(':');
                    int selecteditemid = Convert.ToInt32(selecteditems[0]);
                    mdsb.RemoveLikeToFile(selecteditemid, userID);
                    likes = mdsb.GetAllLikes(selecteditemid);
                    MessageBox.Show("Unliked!");
                    tbfileinfo.Clear();
                }
                else
                {
                    string selecteditem = FileBox.SelectedItem.ToString();
                    string[] selecteditems = selecteditem.Split(':');
                    int selecteditemid = Convert.ToInt32(selecteditems[0]);
                    mdsb.AddLikeToFile(selecteditemid, userID);
                    likes = mdsb.GetAllLikes(selecteditemid);
                    MessageBox.Show("Liked!");
                    tbfileinfo.Clear();

                }


            }
            if (FileBox.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
            {
                if (btnLike.Text == "Unlike")
                {
                    string selecteditem = listBox1.SelectedItem.ToString();
                    string[] selecteditems = selecteditem.Split(':', ' ');
                    int selecteditemid = Convert.ToInt32(selecteditems[2]);
                    mdsb.RemoveLikeToReply(selecteditemid, userID);
                    likesreply = mdsb.GetAllLikesReply(selecteditemid);
                }
                else
                {
                    string selecteditem = listBox1.SelectedItem.ToString();
                    string[] selecteditems = selecteditem.Split(':', ' ');
                    int selecteditemid = Convert.ToInt32(selecteditems[2]);
                    mdsb.AddLikeToReply(selecteditemid, userID);
                    likesreply = mdsb.GetAllLikesReply(selecteditemid);

                }

            }

            Refresh();
            RefreshFilebox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer een reply");
            }
            else
            {
                string selecteditem = listBox1.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':', ' ');
                int selecteditemid = Convert.ToInt32(selecteditems[2]);
                likesreply = mdsb.GetAllLikesReply(selecteditemid);

                Mediaitems = mdsb.AlreadyLiked();


                foreach (Mediaitem itemstext in Mediatext)
                {
                    foreach (Mediaitem itemslikes in Mediaitems)
                    {
                    if (itemstext.UserID == userID && itemstext.Mediaitemid == selecteditemid && itemstext.Mediaitemid == itemslikes.Mediacategoryid)
                    {
                        btnLike.Text = "Unlike";
                        break;
                    }
                    else
                    {
                        btnLike.Text = "Like";
                    }
                    }
                    
                }


            
        
                }

}

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (FileBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a file");
            }
            if (FileBox.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
            {
                MessageBox.Show("You cannot give a reply on a reply, please select a file only");
            }
            else
            {
                string selecteditem = FileBox.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':');
                selecteditem = selecteditems[0];
                mdsb.AddReplytofile(tbReply.Text, Convert.ToInt32(selecteditem), userID);
            }
            Refresh();
            RefreshFilebox();
            RefreshListbox();
    }

        private void btnSpam_Click(object sender, EventArgs e)
        {
            if (FileBox.SelectedIndex == -1)
            {
                MessageBox.Show("Kies een file");
            }
            if (FileBox.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
            {
                MessageBox.Show("Please report only files");
            }
            else
            {
                string selecteditem = FileBox.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':', ' ');
                int selecteditemid = Convert.ToInt32(selecteditems[0]);

                Report checkreport = mdsb.GetSingleReport(selecteditemid, userID);
                if( checkreport == null)
             {
                 mdsb.AddReport(selecteditemid, userID);
             }
             else
                {
                    MessageBox.Show("already reported");
                }
              
              
                
            }
            RefreshReportList();
        }

        private void FileBox_Click(object sender, EventArgs e)
        {
            string selecteditem = FileBox.SelectedItem.ToString();
            string[] selecteditems = selecteditem.Split(':', ' ');
            int selecteditemid = Convert.ToInt32(selecteditems[0]);
            Mediatext = mdsb.Getmediatextlist(selecteditemid);

            Refresh();
            RefreshListbox();
        }

     



    }
}
