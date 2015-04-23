using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Windows.Forms;
using Businesslayer;
using System.IO;
using Businesslayer.Business;
using Businesslayer.DAL;


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

            if (Userlogin.Loggeduser.Isadmin == false)
            {
                tabControl1.TabPages.RemoveAt(2);
            }

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
        private int MediaCategoryID;
        private int likes;
        private int likesreply;
        private int categoryID;
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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSelectFile.Text = openFileDialog1.FileName;
                FileInfo F = new FileInfo(openFileDialog1.FileName);
                size = Convert.ToInt32(F.Length/1000);
                filetype = F.Extension;
            }


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
                userID = Userlogin.Loggeduser.ID;             
                MediaCategoryID = mdsb.GetMediaCategory(cbCategory.SelectedItem.ToString());

                if (type == "" || title == "" || description == "" || category == null || filepath == null)
                {
                    MessageBox.Show("Not all info is filled in");
                }
                else
                {
                    int mediaitemID = mdsb.GetmediaitemID(title);
                    Mediaitems = mdsb.Getallmediaitems();
                    FileInfo f = new FileInfo(filepath);
                    string uploadloc = @"C:\Opdracht" + "/" + f.Name;
                    System.IO.File.Copy(filepath, uploadloc, false);
                    MessageBox.Show("File uploaded: " + f.Name);
                    this.Close();
                    Mediaitem newmedia = new Mediaitem(type, title, description, filepath, userID, size,
                        filetype, MediaCategoryID);
                }
                
            }
            catch (SystemException exc)
            {
                MessageBox.Show("Error moving file:" + exc.Message + "Something wrong with the file, or not all textboxes filled in");
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

        public void RefreshFilebox2()
        {

            
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
                if (FileBox.SelectedIndex == -1 || listBox1.SelectedIndex != -1)
                {
                    MessageBox.Show("No item selected / cant delete an reply");
                    
                }
                else
                {
                    string selecteditem = FileBox.SelectedItem.ToString();
                    string[] selecteditems = selecteditem.Split(':');
                    selecteditem = selecteditems[1];
                    Mediaitem item = Mediaitems.Find(x => x.Title == selecteditem);
                    int selectedid = Convert.ToInt32(selecteditems[0]);
                    Mediaitem itemfile = mdsb.Getsinglemediaitemfile(selectedid);
                    int itemUserID = mdsb.GetUserID(selectedid);
                    if (Userlogin.Loggeduser.Isadmin == false)
                    {
                        if (userID == itemUserID)
                        {
                           
                                System.IO.File.Delete(itemfile.Filepath);
                                mdsb.RemoveMediaItem(item);
                                mdsb.RemoveMediaItemFile(item);
                            

                        }

                        else
                        {
                            MessageBox.Show("Je hebt geen bevoegdheid om deze file te verwijderen");
                        }

                    }
                    else
                    {
                        System.IO.File.Delete(itemfile.Filepath);
                        mdsb.RemoveMediaItem(item);
                        mdsb.RemoveMediaItemFile(item);
                    }
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
                //Not needed, already implemented in another event
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


                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo f = new FileInfo(filepath);
                        string uploadloc = @"C:\Opdracht" + "/" + f.Name;
                        System.IO.File.Copy(uploadloc, openFileDialog1.FileName, false);
                     
                        this.Close();
                    }
                    catch (SystemException exc)
                    {
                        MessageBox.Show("Error moving file:" + exc.Message);
                    }
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
            else if (FileBox.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
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
            else if (FileBox.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
            {
                MessageBox.Show("Please report only files");
            }
            else
            {
                string selecteditem = FileBox.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':', ' ');
                int selecteditemid = Convert.ToInt32(selecteditems[0]);

                Report checkreport = mdsb.GetSingleReport(selecteditemid, userID);
                if( checkreport.MediaitemID == 0)
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
            if (FileBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a file");
            }
            else
            {
                string selecteditem = FileBox.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':', ' ');
                int selecteditemid = Convert.ToInt32(selecteditems[0]);
                Mediatext = mdsb.Getmediatextlist(selecteditemid);
            }
            

            Refresh();
            RefreshListbox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Select a file");
            }
            else
            {
                string selecteditem = listBox2.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':', ' ');
                int selecteditemid = Convert.ToInt32(selecteditems[8]);
                tabControl1.SelectedTab = tabPage1;
                FileBox.SelectedIndex = selecteditemid - 1;
            }
   



        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReportList();
            cbCategory.Items.Clear();
            Categories = mdsb.GetAllCategories();
            foreach (string categorie in Categories)
            {
                cbCategory.Items.Add(categorie);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Select a report");
            }
            else
            {
                string selecteditem = listBox2.SelectedItem.ToString();
                string[] selecteditems = selecteditem.Split(':', ' ');
                int selecteditemid = Convert.ToInt32(selecteditems[8]);
                mdsb.RemoveReportedFile(selecteditemid, userID);
                RefreshReportList();          
            }
            
        }
        

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            string Title = tbsearch.Text;
            string SortOn = cbsearch.Text;

            if (Title == "" || SortOn == "")
            {
                MessageBox.Show("fill in the boxes");
            }
            else
            {
                if (SortOn == "Title")
                {
                    Mediaitems = mdsb.SearchOnTitle(Title);

                    if (Title == "")
                    {
                        RefreshFilebox();
                    }
                    else
                    {
                        RefreshFilebox2();
                    }

                }
                else
                {
                    if (SortOn == "Category")
                    {
                        Mediaitems = mdsb.SearchOnCategory(Title);

                    }

                }
            }
          
            RefreshFilebox2();
        }

        private void cbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     



    }
}
