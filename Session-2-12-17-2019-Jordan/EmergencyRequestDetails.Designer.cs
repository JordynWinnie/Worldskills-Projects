namespace Session2__17_12_2019
{
    partial class EmergencyRequestDetails
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.assetSnLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.assetNameLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.departmentLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.startDateDtp = new System.Windows.Forms.DateTimePicker();
            this.amountTb = new System.Windows.Forms.TextBox();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addToListBtn = new System.Windows.Forms.Button();
            this.assetViewDGV = new System.Windows.Forms.DataGridView();
            this.technicianNoteTb = new System.Windows.Forms.TextBox();
            this.endDateDtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetViewDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.departmentLbl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.assetNameLbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.assetSnLbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Asset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.endDateDtp);
            this.groupBox2.Controls.Add(this.technicianNoteTb);
            this.groupBox2.Controls.Add(this.startDateDtp);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(13, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(914, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asset EM Report";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.assetViewDGV);
            this.groupBox3.Controls.Add(this.addToListBtn);
            this.groupBox3.Controls.Add(this.partNameCb);
            this.groupBox3.Controls.Add(this.amountTb);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(13, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(914, 216);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Replacement Parts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset SN:";
            // 
            // assetSnLbl
            // 
            this.assetSnLbl.AutoSize = true;
            this.assetSnLbl.Location = new System.Drawing.Point(127, 37);
            this.assetSnLbl.Name = "assetSnLbl";
            this.assetSnLbl.Size = new System.Drawing.Size(46, 17);
            this.assetSnLbl.TabIndex = 1;
            this.assetSnLbl.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Name:";
            // 
            // assetNameLbl
            // 
            this.assetNameLbl.AutoSize = true;
            this.assetNameLbl.Location = new System.Drawing.Point(344, 37);
            this.assetNameLbl.Name = "assetNameLbl";
            this.assetNameLbl.Size = new System.Drawing.Size(46, 17);
            this.assetNameLbl.TabIndex = 3;
            this.assetNameLbl.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Department:";
            // 
            // departmentLbl
            // 
            this.departmentLbl.AutoSize = true;
            this.departmentLbl.Location = new System.Drawing.Point(548, 37);
            this.departmentLbl.Name = "departmentLbl";
            this.departmentLbl.Size = new System.Drawing.Size(46, 17);
            this.departmentLbl.TabIndex = 5;
            this.departmentLbl.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Start Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(456, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "End Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Technician Note:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Part Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Amount:";
            // 
            // startDateDtp
            // 
            this.startDateDtp.Location = new System.Drawing.Point(89, 21);
            this.startDateDtp.Name = "startDateDtp";
            this.startDateDtp.Size = new System.Drawing.Size(313, 22);
            this.startDateDtp.TabIndex = 4;
            // 
            // amountTb
            // 
            this.amountTb.Location = new System.Drawing.Point(98, 49);
            this.amountTb.Name = "amountTb";
            this.amountTb.Size = new System.Drawing.Size(292, 22);
            this.amountTb.TabIndex = 3;
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(98, 19);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(292, 24);
            this.partNameCb.TabIndex = 4;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(29, 465);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(176, 38);
            this.SubmitBtn.TabIndex = 2;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(211, 465);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(176, 38);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // addToListBtn
            // 
            this.addToListBtn.Location = new System.Drawing.Point(502, 19);
            this.addToListBtn.Name = "addToListBtn";
            this.addToListBtn.Size = new System.Drawing.Size(406, 43);
            this.addToListBtn.TabIndex = 5;
            this.addToListBtn.Text = "+ Add To List";
            this.addToListBtn.UseVisualStyleBackColor = true;
            this.addToListBtn.Click += new System.EventHandler(this.addToListBtn_Click);
            // 
            // assetViewDGV
            // 
            this.assetViewDGV.AllowUserToAddRows = false;
            this.assetViewDGV.AllowUserToDeleteRows = false;
            this.assetViewDGV.AllowUserToOrderColumns = true;
            this.assetViewDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetViewDGV.Location = new System.Drawing.Point(13, 99);
            this.assetViewDGV.Name = "assetViewDGV";
            this.assetViewDGV.RowHeadersWidth = 51;
            this.assetViewDGV.RowTemplate.Height = 24;
            this.assetViewDGV.Size = new System.Drawing.Size(895, 100);
            this.assetViewDGV.TabIndex = 6;
            this.assetViewDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assetViewDGV_CellClick);
            // 
            // technicianNoteTb
            // 
            this.technicianNoteTb.Location = new System.Drawing.Point(63, 68);
            this.technicianNoteTb.Multiline = true;
            this.technicianNoteTb.Name = "technicianNoteTb";
            this.technicianNoteTb.Size = new System.Drawing.Size(845, 44);
            this.technicianNoteTb.TabIndex = 5;
            // 
            // endDateDtp
            // 
            this.endDateDtp.Location = new System.Drawing.Point(533, 21);
            this.endDateDtp.Name = "endDateDtp";
            this.endDateDtp.Size = new System.Drawing.Size(313, 22);
            this.endDateDtp.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Parts List:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 454);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "[DEBUG: PRINT ALL ITEMS IN TABLE]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(745, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // EmergencyRequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmergencyRequestDetails";
            this.Text = "EmergencyRequestDetails";
            this.Load += new System.EventHandler(this.EmergencyRequestDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetViewDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label departmentLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label assetNameLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label assetSnLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker startDateDtp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView assetViewDGV;
        private System.Windows.Forms.Button addToListBtn;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox technicianNoteTb;
        private System.Windows.Forms.DateTimePicker endDateDtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}