namespace Proftaak
{
    partial class Mediasharing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbfileinfo = new System.Windows.Forms.TextBox();
            this.btnUploadMedia = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.tbReply = new System.Windows.Forms.RichTextBox();
            this.btnSpam = new System.Windows.Forms.Button();
            this.btnDownloadMedia = new System.Windows.Forms.Button();
            this.btnDeleteMedia = new System.Windows.Forms.Button();
            this.FileBox = new System.Windows.Forms.ListBox();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.tbsearch = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbtypetab2 = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUploadMediaTab2 = new System.Windows.Forms.Button();
            this.tbSelectFile = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 547);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.btnLike);
            this.tabPage1.Controls.Add(this.btnReply);
            this.tabPage1.Controls.Add(this.tbReply);
            this.tabPage1.Controls.Add(this.btnSpam);
            this.tabPage1.Controls.Add(this.btnDownloadMedia);
            this.tabPage1.Controls.Add(this.btnDeleteMedia);
            this.tabPage1.Controls.Add(this.FileBox);
            this.tabPage1.Controls.Add(this.cbtype);
            this.tabPage1.Controls.Add(this.tbsearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(961, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MediaSharing";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(208, 87);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(537, 290);
            this.listBox1.TabIndex = 12;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbfileinfo);
            this.groupBox3.Controls.Add(this.btnUploadMedia);
            this.groupBox3.Location = new System.Drawing.Point(202, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 80);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File Info";
            // 
            // tbfileinfo
            // 
            this.tbfileinfo.Location = new System.Drawing.Point(6, 14);
            this.tbfileinfo.Multiline = true;
            this.tbfileinfo.Name = "tbfileinfo";
            this.tbfileinfo.Size = new System.Drawing.Size(388, 61);
            this.tbfileinfo.TabIndex = 12;
            // 
            // btnUploadMedia
            // 
            this.btnUploadMedia.Location = new System.Drawing.Point(400, 14);
            this.btnUploadMedia.Name = "btnUploadMedia";
            this.btnUploadMedia.Size = new System.Drawing.Size(137, 56);
            this.btnUploadMedia.TabIndex = 7;
            this.btnUploadMedia.Text = "Upload media";
            this.btnUploadMedia.UseVisualStyleBackColor = true;
            this.btnUploadMedia.Click += new System.EventHandler(this.btnUploadMedia_Click);
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(602, 422);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(143, 23);
            this.btnLike.TabIndex = 10;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(602, 393);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(143, 23);
            this.btnReply.TabIndex = 9;
            this.btnReply.Text = "Give a reply";
            this.btnReply.UseVisualStyleBackColor = true;
            // 
            // tbReply
            // 
            this.tbReply.Location = new System.Drawing.Point(202, 395);
            this.tbReply.Name = "tbReply";
            this.tbReply.Size = new System.Drawing.Size(394, 47);
            this.tbReply.TabIndex = 8;
            this.tbReply.Text = "";
            // 
            // btnSpam
            // 
            this.btnSpam.Location = new System.Drawing.Point(18, 412);
            this.btnSpam.Name = "btnSpam";
            this.btnSpam.Size = new System.Drawing.Size(178, 30);
            this.btnSpam.TabIndex = 6;
            this.btnSpam.Text = "Report as spam";
            this.btnSpam.UseVisualStyleBackColor = true;
            // 
            // btnDownloadMedia
            // 
            this.btnDownloadMedia.Location = new System.Drawing.Point(18, 376);
            this.btnDownloadMedia.Name = "btnDownloadMedia";
            this.btnDownloadMedia.Size = new System.Drawing.Size(178, 30);
            this.btnDownloadMedia.TabIndex = 5;
            this.btnDownloadMedia.Text = "Download media";
            this.btnDownloadMedia.UseVisualStyleBackColor = true;
            this.btnDownloadMedia.Click += new System.EventHandler(this.btnDownloadMedia_Click);
            // 
            // btnDeleteMedia
            // 
            this.btnDeleteMedia.Location = new System.Drawing.Point(18, 340);
            this.btnDeleteMedia.Name = "btnDeleteMedia";
            this.btnDeleteMedia.Size = new System.Drawing.Size(178, 30);
            this.btnDeleteMedia.TabIndex = 3;
            this.btnDeleteMedia.Text = "Delete media";
            this.btnDeleteMedia.UseVisualStyleBackColor = true;
            this.btnDeleteMedia.Click += new System.EventHandler(this.btnDeleteMedia_Click);
            // 
            // FileBox
            // 
            this.FileBox.FormattingEnabled = true;
            this.FileBox.Location = new System.Drawing.Point(18, 87);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(178, 251);
            this.FileBox.TabIndex = 2;
            this.FileBox.SelectedIndexChanged += new System.EventHandler(this.FileBox_SelectedIndexChanged);
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "Media"});
            this.cbtype.Location = new System.Drawing.Point(18, 46);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(178, 21);
            this.cbtype.TabIndex = 1;
            // 
            // tbsearch
            // 
            this.tbsearch.Location = new System.Drawing.Point(18, 20);
            this.tbsearch.Name = "tbsearch";
            this.tbsearch.Size = new System.Drawing.Size(178, 20);
            this.tbsearch.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(961, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Upload media";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbtypetab2);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.btnUploadMediaTab2);
            this.groupBox1.Controls.Add(this.tbSelectFile);
            this.groupBox1.Controls.Add(this.tbDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 389);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Media";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Category :";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Horror",
            "Happy",
            "Epic Dance moeves at tha clup brah"});
            this.cbCategory.Location = new System.Drawing.Point(67, 283);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(164, 21);
            this.cbCategory.TabIndex = 22;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Choose the media type you would like to upload :";
            // 
            // cbtypetab2
            // 
            this.cbtypetab2.FormattingEnabled = true;
            this.cbtypetab2.Items.AddRange(new object[] {
            "Picture",
            "Video",
            "Text"});
            this.cbtypetab2.Location = new System.Drawing.Point(250, 18);
            this.cbtypetab2.Name = "cbtypetab2";
            this.cbtypetab2.Size = new System.Drawing.Size(87, 21);
            this.cbtypetab2.TabIndex = 11;
            this.cbtypetab2.SelectedIndexChanged += new System.EventHandler(this.cbtypetab2_SelectedIndexChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(237, 247);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 23);
            this.btnBrowse.TabIndex = 21;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUploadMediaTab2
            // 
            this.btnUploadMediaTab2.Location = new System.Drawing.Point(9, 360);
            this.btnUploadMediaTab2.Name = "btnUploadMediaTab2";
            this.btnUploadMediaTab2.Size = new System.Drawing.Size(328, 23);
            this.btnUploadMediaTab2.TabIndex = 11;
            this.btnUploadMediaTab2.Text = "Upload Media";
            this.btnUploadMediaTab2.UseVisualStyleBackColor = true;
            this.btnUploadMediaTab2.Click += new System.EventHandler(this.btnUploadMediaTab2_Click);
            // 
            // tbSelectFile
            // 
            this.tbSelectFile.Location = new System.Drawing.Point(9, 247);
            this.tbSelectFile.Name = "tbSelectFile";
            this.tbSelectFile.Size = new System.Drawing.Size(222, 20);
            this.tbSelectFile.TabIndex = 20;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(9, 117);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(328, 81);
            this.tbDescription.TabIndex = 10;
            this.tbDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Title :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Select File :";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(9, 66);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(328, 20);
            this.tbTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Description / Text :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.listBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(961, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reports";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(9, 129);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(115, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "Navigate to post";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete Report";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delete Report:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(116, 20);
            this.textBox3.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "ReportID : 1, Name : Chris, MediaTitle : Kijk deze shit! ",
            "ReportedBy : Rob, Description : Abusieve taalgebruik in de titel"});
            this.listBox2.Location = new System.Drawing.Point(141, 6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(329, 433);
            this.listBox2.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Mediasharing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 473);
            this.Controls.Add(this.tabControl1);
            this.Name = "Mediasharing";
            this.Text = "Mediasharing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mediasharing_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.TextBox tbsearch;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.RichTextBox tbReply;
        private System.Windows.Forms.Button btnUploadMedia;
        private System.Windows.Forms.Button btnSpam;
        private System.Windows.Forms.Button btnDownloadMedia;
        private System.Windows.Forms.Button btnDeleteMedia;
        private System.Windows.Forms.ListBox FileBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbtypetab2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUploadMediaTab2;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbSelectFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox tbfileinfo;
    }
}