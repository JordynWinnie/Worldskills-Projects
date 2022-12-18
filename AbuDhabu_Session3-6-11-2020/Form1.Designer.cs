namespace AbuDhabu_Session3_6_11_2020
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.returnRadio = new System.Windows.Forms.RadioButton();
            this.onewayRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outboundDTP = new System.Windows.Forms.DateTimePicker();
            this.returnDTP = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            this.fromCb = new System.Windows.Forms.ComboBox();
            this.toCb = new System.Windows.Forms.ComboBox();
            this.cabinCb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.outboundCheckBox = new System.Windows.Forms.CheckBox();
            this.outboundFlightDGV = new System.Windows.Forms.DataGridView();
            this.returnFlightDGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.passengersNUD = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.bookBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.returnFlightCheckBox = new System.Windows.Forms.CheckBox();
            this.returnFlightGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundFlightDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnFlightDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passengersNUD)).BeginInit();
            this.returnFlightGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cabinCb);
            this.groupBox1.Controls.Add(this.toCb);
            this.groupBox1.Controls.Add(this.fromCb);
            this.groupBox1.Controls.Add(this.applyBtn);
            this.groupBox1.Controls.Add(this.returnDTP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.outboundDTP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Parameters:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cabin Type:";
            // 
            // returnRadio
            // 
            this.returnRadio.AutoSize = true;
            this.returnRadio.Checked = true;
            this.returnRadio.Location = new System.Drawing.Point(6, 19);
            this.returnRadio.Name = "returnRadio";
            this.returnRadio.Size = new System.Drawing.Size(57, 17);
            this.returnRadio.TabIndex = 3;
            this.returnRadio.TabStop = true;
            this.returnRadio.Text = "Return";
            this.returnRadio.UseVisualStyleBackColor = true;
            // 
            // onewayRadio
            // 
            this.onewayRadio.AutoSize = true;
            this.onewayRadio.Location = new System.Drawing.Point(69, 19);
            this.onewayRadio.Name = "onewayRadio";
            this.onewayRadio.Size = new System.Drawing.Size(67, 17);
            this.onewayRadio.TabIndex = 4;
            this.onewayRadio.Text = "One way";
            this.onewayRadio.UseVisualStyleBackColor = true;
            this.onewayRadio.CheckedChanged += new System.EventHandler(this.onewayRadio_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.onewayRadio);
            this.groupBox2.Controls.Add(this.returnRadio);
            this.groupBox2.Location = new System.Drawing.Point(27, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 47);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Outbound:";
            // 
            // outboundDTP
            // 
            this.outboundDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.outboundDTP.Location = new System.Drawing.Point(271, 89);
            this.outboundDTP.Name = "outboundDTP";
            this.outboundDTP.Size = new System.Drawing.Size(101, 20);
            this.outboundDTP.TabIndex = 7;
            // 
            // returnDTP
            // 
            this.returnDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.returnDTP.Location = new System.Drawing.Point(459, 89);
            this.returnDTP.Name = "returnDTP";
            this.returnDTP.Size = new System.Drawing.Size(101, 20);
            this.returnDTP.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Return:";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(640, 89);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 10;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // fromCb
            // 
            this.fromCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromCb.FormattingEnabled = true;
            this.fromCb.Location = new System.Drawing.Point(83, 30);
            this.fromCb.Name = "fromCb";
            this.fromCb.Size = new System.Drawing.Size(121, 21);
            this.fromCb.TabIndex = 11;
            // 
            // toCb
            // 
            this.toCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toCb.FormattingEnabled = true;
            this.toCb.Location = new System.Drawing.Point(318, 30);
            this.toCb.Name = "toCb";
            this.toCb.Size = new System.Drawing.Size(121, 21);
            this.toCb.TabIndex = 12;
            // 
            // cabinCb
            // 
            this.cabinCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cabinCb.FormattingEnabled = true;
            this.cabinCb.Location = new System.Drawing.Point(618, 27);
            this.cabinCb.Name = "cabinCb";
            this.cabinCb.Size = new System.Drawing.Size(121, 21);
            this.cabinCb.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Outbound Flight Details:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Return Flight Details";
            // 
            // outboundCheckBox
            // 
            this.outboundCheckBox.AutoSize = true;
            this.outboundCheckBox.Location = new System.Drawing.Point(515, 180);
            this.outboundCheckBox.Name = "outboundCheckBox";
            this.outboundCheckBox.Size = new System.Drawing.Size(198, 17);
            this.outboundCheckBox.TabIndex = 16;
            this.outboundCheckBox.Text = "Display Three Days Before and After";
            this.outboundCheckBox.UseVisualStyleBackColor = true;
            // 
            // outboundFlightDGV
            // 
            this.outboundFlightDGV.AllowUserToAddRows = false;
            this.outboundFlightDGV.AllowUserToDeleteRows = false;
            this.outboundFlightDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.outboundFlightDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outboundFlightDGV.Location = new System.Drawing.Point(13, 197);
            this.outboundFlightDGV.Name = "outboundFlightDGV";
            this.outboundFlightDGV.Size = new System.Drawing.Size(775, 174);
            this.outboundFlightDGV.TabIndex = 17;
            this.outboundFlightDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outboundFlightDGV_CellClick);
            // 
            // returnFlightDGV
            // 
            this.returnFlightDGV.AllowUserToAddRows = false;
            this.returnFlightDGV.AllowUserToDeleteRows = false;
            this.returnFlightDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.returnFlightDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returnFlightDGV.Location = new System.Drawing.Point(7, 32);
            this.returnFlightDGV.Name = "returnFlightDGV";
            this.returnFlightDGV.Size = new System.Drawing.Size(775, 174);
            this.returnFlightDGV.TabIndex = 18;
            this.returnFlightDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.returnFlightDGV_CellClick);
        
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bookBtn);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.passengersNUD);
            this.groupBox3.Location = new System.Drawing.Point(209, 598);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 56);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Confirm Booking For:";
            // 
            // passengersNUD
            // 
            this.passengersNUD.Location = new System.Drawing.Point(14, 20);
            this.passengersNUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.passengersNUD.Name = "passengersNUD";
            this.passengersNUD.Size = new System.Drawing.Size(120, 20);
            this.passengersNUD.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "passengers";
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(263, 16);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(147, 23);
            this.bookBtn.TabIndex = 2;
            this.bookBtn.Text = "Book Flight";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 614);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // returnFlightCheckBox
            // 
            this.returnFlightCheckBox.AutoSize = true;
            this.returnFlightCheckBox.Location = new System.Drawing.Point(509, 12);
            this.returnFlightCheckBox.Name = "returnFlightCheckBox";
            this.returnFlightCheckBox.Size = new System.Drawing.Size(198, 17);
            this.returnFlightCheckBox.TabIndex = 20;
            this.returnFlightCheckBox.Text = "Display Three Days Before and After";
            this.returnFlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // returnFlightGroupBox
            // 
            this.returnFlightGroupBox.Controls.Add(this.label7);
            this.returnFlightGroupBox.Controls.Add(this.returnFlightCheckBox);
            this.returnFlightGroupBox.Controls.Add(this.returnFlightDGV);
            this.returnFlightGroupBox.Location = new System.Drawing.Point(12, 377);
            this.returnFlightGroupBox.Name = "returnFlightGroupBox";
            this.returnFlightGroupBox.Size = new System.Drawing.Size(787, 215);
            this.returnFlightGroupBox.TabIndex = 21;
            this.returnFlightGroupBox.TabStop = false;
            this.returnFlightGroupBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 666);
            this.Controls.Add(this.returnFlightGroupBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.outboundFlightDGV);
            this.Controls.Add(this.outboundCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Search For Flights";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundFlightDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnFlightDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passengersNUD)).EndInit();
            this.returnFlightGroupBox.ResumeLayout(false);
            this.returnFlightGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cabinCb;
        private System.Windows.Forms.ComboBox toCb;
        private System.Windows.Forms.ComboBox fromCb;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.DateTimePicker returnDTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker outboundDTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton onewayRadio;
        private System.Windows.Forms.RadioButton returnRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox outboundCheckBox;
        private System.Windows.Forms.DataGridView outboundFlightDGV;
        private System.Windows.Forms.DataGridView returnFlightDGV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown passengersNUD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox returnFlightCheckBox;
        private System.Windows.Forms.GroupBox returnFlightGroupBox;
    }
}

