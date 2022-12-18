namespace AbuDhabu_Session3_6_11_2020
{
    partial class BookingConfirmationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outboundDGV = new System.Windows.Forms.DataGridView();
            this.returnFlightGroupBox = new System.Windows.Forms.GroupBox();
            this.returnDGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.firstNameTb = new System.Windows.Forms.TextBox();
            this.lastNameTb = new System.Windows.Forms.TextBox();
            this.birthdateDTP = new System.Windows.Forms.DateTimePicker();
            this.passportNoTb = new System.Windows.Forms.TextBox();
            this.countryCb = new System.Windows.Forms.ComboBox();
            this.phoneTb = new System.Windows.Forms.TextBox();
            this.addPassenger = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.passengerDGV = new System.Windows.Forms.DataGridView();
            this.removePassengerBtn = new System.Windows.Forms.Button();
            this.selectFlightsBtn = new System.Windows.Forms.Button();
            this.confirmBookingBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundDGV)).BeginInit();
            this.returnFlightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.returnDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passengerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outboundDGV);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outbound Flight Summary";
            // 
            // outboundDGV
            // 
            this.outboundDGV.AllowUserToAddRows = false;
            this.outboundDGV.AllowUserToDeleteRows = false;
            this.outboundDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outboundDGV.Location = new System.Drawing.Point(7, 20);
            this.outboundDGV.Name = "outboundDGV";
            this.outboundDGV.Size = new System.Drawing.Size(762, 136);
            this.outboundDGV.TabIndex = 0;
            // 
            // returnFlightGroupBox
            // 
            this.returnFlightGroupBox.Controls.Add(this.returnDGV);
            this.returnFlightGroupBox.Location = new System.Drawing.Point(13, 190);
            this.returnFlightGroupBox.Name = "returnFlightGroupBox";
            this.returnFlightGroupBox.Size = new System.Drawing.Size(775, 162);
            this.returnFlightGroupBox.TabIndex = 1;
            this.returnFlightGroupBox.TabStop = false;
            this.returnFlightGroupBox.Text = "Return Flight Summary";
            // 
            // returnDGV
            // 
            this.returnDGV.AllowUserToAddRows = false;
            this.returnDGV.AllowUserToDeleteRows = false;
            this.returnDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returnDGV.Location = new System.Drawing.Point(7, 20);
            this.returnDGV.Name = "returnDGV";
            this.returnDGV.Size = new System.Drawing.Size(762, 136);
            this.returnDGV.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addPassenger);
            this.groupBox3.Controls.Add(this.phoneTb);
            this.groupBox3.Controls.Add(this.countryCb);
            this.groupBox3.Controls.Add(this.passportNoTb);
            this.groupBox3.Controls.Add(this.birthdateDTP);
            this.groupBox3.Controls.Add(this.lastNameTb);
            this.groupBox3.Controls.Add(this.firstNameTb);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(13, 359);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(769, 188);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Passenger Details:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Birthdate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Passport No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Country:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(559, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Phone:";
            // 
            // firstNameTb
            // 
            this.firstNameTb.Location = new System.Drawing.Point(95, 43);
            this.firstNameTb.Name = "firstNameTb";
            this.firstNameTb.Size = new System.Drawing.Size(182, 20);
            this.firstNameTb.TabIndex = 6;
            // 
            // lastNameTb
            // 
            this.lastNameTb.Location = new System.Drawing.Point(350, 43);
            this.lastNameTb.Name = "lastNameTb";
            this.lastNameTb.Size = new System.Drawing.Size(182, 20);
            this.lastNameTb.TabIndex = 7;
            // 
            // birthdateDTP
            // 
            this.birthdateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdateDTP.Location = new System.Drawing.Point(618, 43);
            this.birthdateDTP.Name = "birthdateDTP";
            this.birthdateDTP.Size = new System.Drawing.Size(134, 20);
            this.birthdateDTP.TabIndex = 8;
            // 
            // passportNoTb
            // 
            this.passportNoTb.Location = new System.Drawing.Point(95, 111);
            this.passportNoTb.Name = "passportNoTb";
            this.passportNoTb.Size = new System.Drawing.Size(182, 20);
            this.passportNoTb.TabIndex = 9;
            // 
            // countryCb
            // 
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(350, 109);
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(182, 21);
            this.countryCb.TabIndex = 10;
            // 
            // phoneTb
            // 
            this.phoneTb.Location = new System.Drawing.Point(618, 108);
            this.phoneTb.Name = "phoneTb";
            this.phoneTb.Size = new System.Drawing.Size(134, 20);
            this.phoneTb.TabIndex = 11;
            // 
            // addPassenger
            // 
            this.addPassenger.Location = new System.Drawing.Point(31, 151);
            this.addPassenger.Name = "addPassenger";
            this.addPassenger.Size = new System.Drawing.Size(721, 23);
            this.addPassenger.TabIndex = 12;
            this.addPassenger.Text = "Add Passenger";
            this.addPassenger.UseVisualStyleBackColor = true;
            this.addPassenger.Click += new System.EventHandler(this.addPassenger_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 561);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Passengers List:";
            // 
            // passengerDGV
            // 
            this.passengerDGV.AllowUserToAddRows = false;
            this.passengerDGV.AllowUserToDeleteRows = false;
            this.passengerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.passengerDGV.Location = new System.Drawing.Point(20, 578);
            this.passengerDGV.Name = "passengerDGV";
            this.passengerDGV.Size = new System.Drawing.Size(762, 150);
            this.passengerDGV.TabIndex = 14;
            this.passengerDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.passengerDGV_CellClick);
            // 
            // removePassengerBtn
            // 
            this.removePassengerBtn.Location = new System.Drawing.Point(20, 735);
            this.removePassengerBtn.Name = "removePassengerBtn";
            this.removePassengerBtn.Size = new System.Drawing.Size(762, 23);
            this.removePassengerBtn.TabIndex = 15;
            this.removePassengerBtn.Text = "Remove Passenger";
            this.removePassengerBtn.UseVisualStyleBackColor = true;
            this.removePassengerBtn.Click += new System.EventHandler(this.removePassengerBtn_Click);
            // 
            // selectFlightsBtn
            // 
            this.selectFlightsBtn.Location = new System.Drawing.Point(20, 795);
            this.selectFlightsBtn.Name = "selectFlightsBtn";
            this.selectFlightsBtn.Size = new System.Drawing.Size(209, 23);
            this.selectFlightsBtn.TabIndex = 16;
            this.selectFlightsBtn.Text = "Return To Select Flights";
            this.selectFlightsBtn.UseVisualStyleBackColor = true;
            this.selectFlightsBtn.Click += new System.EventHandler(this.selectFlightsBtn_Click);
            // 
            // confirmBookingBtn
            // 
            this.confirmBookingBtn.Location = new System.Drawing.Point(235, 795);
            this.confirmBookingBtn.Name = "confirmBookingBtn";
            this.confirmBookingBtn.Size = new System.Drawing.Size(209, 23);
            this.confirmBookingBtn.TabIndex = 17;
            this.confirmBookingBtn.Text = "Confirm Booking";
            this.confirmBookingBtn.UseVisualStyleBackColor = true;
            this.confirmBookingBtn.Click += new System.EventHandler(this.confirmBookingBtn_Click);
            // 
            // BookingConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 830);
            this.Controls.Add(this.confirmBookingBtn);
            this.Controls.Add(this.selectFlightsBtn);
            this.Controls.Add(this.removePassengerBtn);
            this.Controls.Add(this.passengerDGV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.returnFlightGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "BookingConfirmationForm";
            this.Text = "BookingConfirmationForm";
            this.Load += new System.EventHandler(this.BookingConfirmationForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outboundDGV)).EndInit();
            this.returnFlightGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.returnDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passengerDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView outboundDGV;
        private System.Windows.Forms.GroupBox returnFlightGroupBox;
        private System.Windows.Forms.DataGridView returnDGV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button addPassenger;
        private System.Windows.Forms.TextBox phoneTb;
        private System.Windows.Forms.ComboBox countryCb;
        private System.Windows.Forms.TextBox passportNoTb;
        private System.Windows.Forms.DateTimePicker birthdateDTP;
        private System.Windows.Forms.TextBox lastNameTb;
        private System.Windows.Forms.TextBox firstNameTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView passengerDGV;
        private System.Windows.Forms.Button removePassengerBtn;
        private System.Windows.Forms.Button selectFlightsBtn;
        private System.Windows.Forms.Button confirmBookingBtn;
    }
}