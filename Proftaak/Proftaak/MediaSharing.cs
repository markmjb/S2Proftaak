using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Businesslayer;
using System.IO;
using Businesslayer.Business;


namespace Proftaak
{
    public partial class Mediasharing : Form
    {
        Mediasharingbusiness mdsb = new Mediasharingbusiness();
        Userlogin userl = new Userlogin();
        public Mediasharing()
        {
            InitializeComponent();
            
        }
       
       private string type;
       private string description;
       private string category;
       private string filepath;
       private string title;
       private string filetype;
       private int size;
       private int userID;
       private int categoryID;
       
        List<Mediaitem> Mediaitems = new List<Mediaitem>();


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
            size = Convert.ToInt32(F.Length / 1000);
            filetype = F.Extension;
    

           
        }

        private void btnUploadMediaTab2_Click(object sender, EventArgs e)
        {

          type = cbtypetab2.Text;
          title = tbTitle.Text;
          description = tbDescription.Text;
          filepath = tbSelectFile.Text;
          category = cbCategory.Text;
          categoryID = 3;
          userID = Userlogin.Loggeduser.ID;
         
          

          Mediaitem newmedia = new Mediaitem(type, title, description, filepath, categoryID, userID, size, filetype);
         
          int mediaitemID = mdsb.GetmediaitemID(title);

          Mediaitems = mdsb.Getallmediaitems();
            foreach (Mediaitem mediaitem in Mediaitems)
            {
                FileBox.Items.Add(mediaitem.ToString());

            }
          mdsb.GetmediaitemID(title);


            
          





        }

        public int getcategory()
        {
            categoryID = mdsb.getcategory(category);
            return categoryID;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
      
    }
}
