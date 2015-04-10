using System;
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
    public partial class Mediasharing : Form
    {
        public Mediasharing()
        {
            InitializeComponent();
            
        }

       private string type;
       private string description;
       private string category;
       private string filepath;
       private string title;


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

            
          

          

          

        }
    }
}
