namespace Proftaak
{
    partial class EventControl
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
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.btnEditEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.datagridEvents = new System.Windows.Forms.DataGridView();
            this.columnEventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnEventStartdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnEventEnddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblStreetnumber = new System.Windows.Forms.Label();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbProvince = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.nudStreetnumber = new System.Windows.Forms.NumericUpDown();
            this.tbPostalcode = new System.Windows.Forms.TextBox();
            this.nudTicketprice = new System.Windows.Forms.NumericUpDown();
            this.lblEventID = new System.Windows.Forms.Label();
            this.lblEventIDValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStreetnumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTicketprice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Location = new System.Drawing.Point(319, 328);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(287, 23);
            this.btnCreateEvent.TabIndex = 0;
            this.btnCreateEvent.Text = "Create Event";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // btnEditEvent
            // 
            this.btnEditEvent.Location = new System.Drawing.Point(449, 168);
            this.btnEditEvent.Name = "btnEditEvent";
            this.btnEditEvent.Size = new System.Drawing.Size(76, 23);
            this.btnEditEvent.TabIndex = 1;
            this.btnEditEvent.Text = "Edit";
            this.btnEditEvent.UseVisualStyleBackColor = true;
            this.btnEditEvent.Click += new System.EventHandler(this.btnEditEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(531, 168);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEvent.TabIndex = 2;
            this.btnDeleteEvent.Text = "Delete";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price Per Ticket: ";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(75, 251);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(220, 20);
            this.dtpStartDate.TabIndex = 7;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(75, 302);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(220, 20);
            this.dtpEndDate.TabIndex = 8;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(75, 206);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(220, 20);
            this.tbName.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(316, 238);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description: ";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(319, 257);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(287, 65);
            this.tbDescription.TabIndex = 12;
            // 
            // datagridEvents
            // 
            this.datagridEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnEventID,
            this.columnEventName,
            this.columnEventStartdate,
            this.columnEventEnddate});
            this.datagridEvents.Location = new System.Drawing.Point(8, 12);
            this.datagridEvents.Name = "datagridEvents";
            this.datagridEvents.Size = new System.Drawing.Size(598, 150);
            this.datagridEvents.TabIndex = 13;
            this.datagridEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridEvents_CellClick);
            // 
            // columnEventID
            // 
            this.columnEventID.HeaderText = "EventID";
            this.columnEventID.Name = "columnEventID";
            this.columnEventID.Width = 125;
            // 
            // columnEventName
            // 
            this.columnEventName.HeaderText = "Name";
            this.columnEventName.Name = "columnEventName";
            this.columnEventName.ReadOnly = true;
            this.columnEventName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnEventName.Width = 125;
            // 
            // columnEventStartdate
            // 
            this.columnEventStartdate.HeaderText = "Startdate";
            this.columnEventStartdate.Name = "columnEventStartdate";
            this.columnEventStartdate.ReadOnly = true;
            this.columnEventStartdate.Width = 125;
            // 
            // columnEventEnddate
            // 
            this.columnEventEnddate.HeaderText = "Enddate";
            this.columnEventEnddate.Name = "columnEventEnddate";
            this.columnEventEnddate.ReadOnly = true;
            this.columnEventEnddate.Width = 125;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(613, 16);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 14;
            this.lblCountry.Text = "Country";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(612, 42);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(49, 13);
            this.lblProvince.TabIndex = 15;
            this.lblProvince.Text = "Province";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(612, 68);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 16;
            this.lblCity.Text = "City";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(612, 94);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(35, 13);
            this.lblStreet.TabIndex = 17;
            this.lblStreet.Text = "Street";
            // 
            // lblStreetnumber
            // 
            this.lblStreetnumber.AutoSize = true;
            this.lblStreetnumber.Location = new System.Drawing.Point(613, 119);
            this.lblStreetnumber.Name = "lblStreetnumber";
            this.lblStreetnumber.Size = new System.Drawing.Size(70, 13);
            this.lblStreetnumber.TabIndex = 18;
            this.lblStreetnumber.Text = "Streetnumber";
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.AutoSize = true;
            this.lblPostalcode.Location = new System.Drawing.Point(613, 146);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(60, 13);
            this.lblPostalcode.TabIndex = 19;
            this.lblPostalcode.Text = "Postalcode";
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(702, 13);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(100, 20);
            this.tbCountry.TabIndex = 20;
            // 
            // tbProvince
            // 
            this.tbProvince.Location = new System.Drawing.Point(702, 39);
            this.tbProvince.Name = "tbProvince";
            this.tbProvince.Size = new System.Drawing.Size(100, 20);
            this.tbProvince.TabIndex = 21;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(702, 65);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(100, 20);
            this.tbCity.TabIndex = 22;
            // 
            // tbStreet
            // 
            this.tbStreet.Location = new System.Drawing.Point(702, 91);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(100, 20);
            this.tbStreet.TabIndex = 23;
            // 
            // nudStreetnumber
            // 
            this.nudStreetnumber.Location = new System.Drawing.Point(702, 117);
            this.nudStreetnumber.Name = "nudStreetnumber";
            this.nudStreetnumber.Size = new System.Drawing.Size(100, 20);
            this.nudStreetnumber.TabIndex = 24;
            // 
            // tbPostalcode
            // 
            this.tbPostalcode.Location = new System.Drawing.Point(702, 143);
            this.tbPostalcode.Name = "tbPostalcode";
            this.tbPostalcode.Size = new System.Drawing.Size(100, 20);
            this.tbPostalcode.TabIndex = 25;
            // 
            // nudTicketprice
            // 
            this.nudTicketprice.DecimalPlaces = 2;
            this.nudTicketprice.Location = new System.Drawing.Point(405, 207);
            this.nudTicketprice.Name = "nudTicketprice";
            this.nudTicketprice.Size = new System.Drawing.Size(120, 20);
            this.nudTicketprice.TabIndex = 26;
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.Location = new System.Drawing.Point(8, 173);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(45, 13);
            this.lblEventID.TabIndex = 27;
            this.lblEventID.Text = "eventID";
            // 
            // lblEventIDValue
            // 
            this.lblEventIDValue.AutoSize = true;
            this.lblEventIDValue.Location = new System.Drawing.Point(72, 173);
            this.lblEventIDValue.Name = "lblEventIDValue";
            this.lblEventIDValue.Size = new System.Drawing.Size(0, 13);
            this.lblEventIDValue.TabIndex = 28;
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 362);
            this.Controls.Add(this.lblEventIDValue);
            this.Controls.Add(this.lblEventID);
            this.Controls.Add(this.nudTicketprice);
            this.Controls.Add(this.tbPostalcode);
            this.Controls.Add(this.nudStreetnumber);
            this.Controls.Add(this.tbStreet);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbProvince);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.lblPostalcode);
            this.Controls.Add(this.lblStreetnumber);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.datagridEvents);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnEditEvent);
            this.Controls.Add(this.btnCreateEvent);
            this.Name = "EventControl";
            this.Text = "EventControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventControl_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.datagridEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStreetnumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTicketprice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Button btnEditEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.DataGridView datagridEvents;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblStreetnumber;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbProvince;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.NumericUpDown nudStreetnumber;
        private System.Windows.Forms.TextBox tbPostalcode;
        private System.Windows.Forms.NumericUpDown nudTicketprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEventStartdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEventEnddate;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.Label lblEventIDValue;
    }
}