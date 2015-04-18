namespace Proftaak
{
    partial class StartScreen
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
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnAccessControl = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.tbNewpass2 = new System.Windows.Forms.TextBox();
            this.tbNewpass1 = new System.Windows.Forms.TextBox();
            this.tbOldpass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMediaSharing = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReservations
            // 
            this.btnReservations.Location = new System.Drawing.Point(12, 12);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(214, 43);
            this.btnReservations.TabIndex = 0;
            this.btnReservations.Text = "Reservations";
            this.btnReservations.UseVisualStyleBackColor = true;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // btnMaterial
            // 
            this.btnMaterial.Location = new System.Drawing.Point(12, 61);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(214, 43);
            this.btnMaterial.TabIndex = 1;
            this.btnMaterial.Text = "Material Control";
            this.btnMaterial.UseVisualStyleBackColor = true;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnAccessControl
            // 
            this.btnAccessControl.Location = new System.Drawing.Point(12, 110);
            this.btnAccessControl.Name = "btnAccessControl";
            this.btnAccessControl.Size = new System.Drawing.Size(214, 43);
            this.btnAccessControl.TabIndex = 2;
            this.btnAccessControl.Text = "Access Control";
            this.btnAccessControl.UseVisualStyleBackColor = true;
            this.btnAccessControl.Click += new System.EventHandler(this.btnAccessControl_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.Location = new System.Drawing.Point(12, 159);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(214, 43);
            this.btnEvents.TabIndex = 3;
            this.btnEvents.Text = "Events";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old Pass: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePass);
            this.groupBox1.Controls.Add(this.tbNewpass2);
            this.groupBox1.Controls.Add(this.tbNewpass1);
            this.groupBox1.Controls.Add(this.tbOldpass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 143);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Password: ";
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(6, 114);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(194, 23);
            this.btnChangePass.TabIndex = 10;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // tbNewpass2
            // 
            this.tbNewpass2.Location = new System.Drawing.Point(86, 85);
            this.tbNewpass2.Name = "tbNewpass2";
            this.tbNewpass2.Size = new System.Drawing.Size(114, 20);
            this.tbNewpass2.TabIndex = 9;
            // 
            // tbNewpass1
            // 
            this.tbNewpass1.Location = new System.Drawing.Point(86, 56);
            this.tbNewpass1.Name = "tbNewpass1";
            this.tbNewpass1.Size = new System.Drawing.Size(114, 20);
            this.tbNewpass1.TabIndex = 8;
            // 
            // tbOldpass
            // 
            this.tbOldpass.Location = new System.Drawing.Point(86, 30);
            this.tbOldpass.Name = "tbOldpass";
            this.tbOldpass.Size = new System.Drawing.Size(114, 20);
            this.tbOldpass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Repeat new: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Pass:";
            // 
            // btnMediaSharing
            // 
            this.btnMediaSharing.Location = new System.Drawing.Point(12, 208);
            this.btnMediaSharing.Name = "btnMediaSharing";
            this.btnMediaSharing.Size = new System.Drawing.Size(214, 43);
            this.btnMediaSharing.TabIndex = 6;
            this.btnMediaSharing.Text = "Mediasharing";
            this.btnMediaSharing.UseVisualStyleBackColor = true;
            this.btnMediaSharing.Click += new System.EventHandler(this.btnMediaSharing_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 420);
            this.Controls.Add(this.btnMediaSharing);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnAccessControl);
            this.Controls.Add(this.btnMaterial);
            this.Controls.Add(this.btnReservations);
            this.Name = "StartScreen";
            this.Text = "StartScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnAccessControl;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.TextBox tbNewpass2;
        private System.Windows.Forms.TextBox tbNewpass1;
        private System.Windows.Forms.TextBox tbOldpass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMediaSharing;
    }
}