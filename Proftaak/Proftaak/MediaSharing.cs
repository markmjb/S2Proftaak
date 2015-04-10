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
       private int userID;
       private int categoryID;


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
        }

        private void btnUploadMediaTab2_Click(object sender, EventArgs e)
        {

          type = cbtypetab2.Text;
          title = tbTitle.Text;
          description = tbDescription.Text;
          filepath = tbSelectFile.Text;
          category = cbCategory.Text;
          categoryID = getcategory();
          userID = userl.LoggedUserID;
          MessageBox.Show(userID.ToString());
          MessageBox.Show(categoryID.ToString());

          Mediaitem newmedia = new Mediaitem(type, title, description, categoryID, userID);  

          

          

          

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
