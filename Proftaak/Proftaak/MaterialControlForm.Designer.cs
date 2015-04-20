namespace Proftaak
{
    partial class MaterialControlForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.Lenen = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbYourItems = new System.Windows.Forms.ComboBox();
            this.cbEvents = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbRFIDNr = new System.Windows.Forms.Label();
            this.lblRFIDreader = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblniks = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lbSelectItem = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblChangePrice = new System.Windows.Forms.Label();
            this.cbItemStock = new System.Windows.Forms.ComboBox();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.label44 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblSETime = new System.Windows.Forms.Label();
            this.Lenen.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select an item";
            // 
            // Lenen
            // 
            this.Lenen.Controls.Add(this.tabPage1);
            this.Lenen.Controls.Add(this.tabPage2);
            this.Lenen.Location = new System.Drawing.Point(-4, 1);
            this.Lenen.Name = "Lenen";
            this.Lenen.SelectedIndex = 0;
            this.Lenen.Size = new System.Drawing.Size(550, 568);
            this.Lenen.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.lblSETime);
            this.tabPage1.Controls.Add(this.lblTime);
            this.tabPage1.Controls.Add(this.cbYourItems);
            this.tabPage1.Controls.Add(this.cbEvents);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.lbRFIDNr);
            this.tabPage1.Controls.Add(this.lblRFIDreader);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblniks);
            this.tabPage1.Controls.Add(this.btnOrder);
            this.tabPage1.Controls.Add(this.lbSelectItem);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label42);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Controls.Add(this.label40);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.nudAmount);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Borrow";
            // 
            // cbYourItems
            // 
            this.cbYourItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYourItems.FormattingEnabled = true;
            this.cbYourItems.Location = new System.Drawing.Point(168, 473);
            this.cbYourItems.Name = "cbYourItems";
            this.cbYourItems.Size = new System.Drawing.Size(140, 21);
            this.cbYourItems.TabIndex = 105;
            this.cbYourItems.SelectedIndexChanged += new System.EventHandler(this.cbYourItems_SelectedIndexChanged);
            // 
            // cbEvents
            // 
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(86, 332);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.Size = new System.Drawing.Size(125, 21);
            this.cbEvents.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 337);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Event:";
            // 
            // lbRFIDNr
            // 
            this.lbRFIDNr.AutoSize = true;
            this.lbRFIDNr.Location = new System.Drawing.Point(308, 50);
            this.lbRFIDNr.Name = "lbRFIDNr";
            this.lbRFIDNr.Size = new System.Drawing.Size(0, 13);
            this.lbRFIDNr.TabIndex = 48;
            this.lbRFIDNr.TextChanged += new System.EventHandler(this.lbRFIDNr_TextChanged);
            // 
            // lblRFIDreader
            // 
            this.lblRFIDreader.AutoSize = true;
            this.lblRFIDreader.Location = new System.Drawing.Point(433, 50);
            this.lblRFIDreader.Name = "lblRFIDreader";
            this.lblRFIDreader.Size = new System.Drawing.Size(29, 13);
            this.lblRFIDreader.TabIndex = 47;
            this.lblRFIDreader.Text = "false";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "RFID reader connected:";
            // 
            // lblniks
            // 
            this.lblniks.AutoSize = true;
            this.lblniks.Location = new System.Drawing.Point(308, 21);
            this.lblniks.Name = "lblniks";
            this.lblniks.Size = new System.Drawing.Size(35, 13);
            this.lblniks.TabIndex = 45;
            this.lblniks.Text = "RFID:";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(355, 330);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(85, 26);
            this.btnOrder.TabIndex = 40;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbSelectItem
            // 
            this.lbSelectItem.FormattingEnabled = true;
            this.lbSelectItem.Location = new System.Drawing.Point(151, 137);
            this.lbSelectItem.Name = "lbSelectItem";
            this.lbSelectItem.ScrollAlwaysVisible = true;
            this.lbSelectItem.Size = new System.Drawing.Size(192, 147);
            this.lbSelectItem.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 26);
            this.button1.TabIndex = 36;
            this.button1.Text = "hand in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(30, 476);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(55, 13);
            this.label42.TabIndex = 33;
            this.label42.Text = "Borrowed:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(166, 416);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(0, 13);
            this.label37.TabIndex = 32;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(166, 392);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(0, 13);
            this.label38.TabIndex = 31;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(30, 416);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(107, 13);
            this.label39.TabIndex = 30;
            this.label39.Text = "Reservation Number:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(30, 392);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(38, 13);
            this.label40.TabIndex = 29;
            this.label40.Text = "Name:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(30, 371);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(113, 13);
            this.label36.TabIndex = 28;
            this.label36.Text = "Scan RFID from visitor";
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(86, 308);
            this.nudAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(125, 20);
            this.nudAmount.TabIndex = 27;
            this.nudAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Amount:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Reservation Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Scan RFID from visitor";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblItems);
            this.tabPage2.Controls.Add(this.lblChangePrice);
            this.tabPage2.Controls.Add(this.cbItemStock);
            this.tabPage2.Controls.Add(this.cbItem);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnChange);
            this.tabPage2.Controls.Add(this.tbPrice);
            this.tabPage2.Controls.Add(this.lbItems);
            this.tabPage2.Controls.Add(this.label44);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.label35);
            this.tabPage2.Controls.Add(this.tbAdd);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(129, 37);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(32, 13);
            this.lblItems.TabIndex = 107;
            this.lblItems.Text = "Items";
            // 
            // lblChangePrice
            // 
            this.lblChangePrice.AutoSize = true;
            this.lblChangePrice.Location = new System.Drawing.Point(47, 265);
            this.lblChangePrice.Name = "lblChangePrice";
            this.lblChangePrice.Size = new System.Drawing.Size(71, 13);
            this.lblChangePrice.TabIndex = 106;
            this.lblChangePrice.Text = "Change Price";
            // 
            // cbItemStock
            // 
            this.cbItemStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemStock.FormattingEnabled = true;
            this.cbItemStock.Location = new System.Drawing.Point(50, 408);
            this.cbItemStock.Name = "cbItemStock";
            this.cbItemStock.Size = new System.Drawing.Size(144, 21);
            this.cbItemStock.TabIndex = 105;
            // 
            // cbItem
            // 
            this.cbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(50, 291);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(144, 21);
            this.cbItem.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "New price:";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(381, 292);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 101;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(288, 292);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(87, 20);
            this.tbPrice.TabIndex = 100;
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(132, 71);
            this.lbItems.Name = "lbItems";
            this.lbItems.ScrollAlwaysVisible = true;
            this.lbItems.Size = new System.Drawing.Size(222, 160);
            this.lbItems.TabIndex = 98;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(47, 380);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(55, 13);
            this.label44.TabIndex = 96;
            this.label44.Text = "Add stock";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(381, 408);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 21);
            this.btnAdd.TabIndex = 94;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(224, 412);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 13);
            this.label35.TabIndex = 93;
            this.label35.Text = "Add:";
            // 
            // tbAdd
            // 
            this.tbAdd.Location = new System.Drawing.Point(288, 409);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(87, 20);
            this.tbAdd.TabIndex = 92;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(30, 444);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(88, 13);
            this.lblTime.TabIndex = 106;
            this.lblTime.Text = "Start/End period:";
            // 
            // lblSETime
            // 
            this.lblSETime.AutoSize = true;
            this.lblSETime.Location = new System.Drawing.Point(166, 444);
            this.lblSETime.Name = "lblSETime";
            this.lblSETime.Size = new System.Drawing.Size(0, 13);
            this.lblSETime.TabIndex = 107;
            // 
            // MaterialControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 554);
            this.Controls.Add(this.Lenen);
            this.Name = "MaterialControlForm";
            this.Text = "Material Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialControlForm_FormClosing);
            this.Load += new System.EventHandler(this.MaterialControlForm_Load);
            this.Lenen.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl Lenen;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.ListBox lbSelectItem;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblniks;
        private System.Windows.Forms.Label lbRFIDNr;
        private System.Windows.Forms.Label lblRFIDreader;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbItemStock;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblChangePrice;
        private System.Windows.Forms.ComboBox cbYourItems;
        private System.Windows.Forms.ComboBox cbEvents;
        private System.Windows.Forms.Label lblSETime;
        private System.Windows.Forms.Label lblTime;

    }
}