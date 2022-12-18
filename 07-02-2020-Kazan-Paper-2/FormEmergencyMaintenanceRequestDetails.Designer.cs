namespace _07_02_2020_Kazan_Paper_2
{
    partial class FormEmergencyMaintenanceRequestDetails
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.submitbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.assetSNLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.assetNameLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.departmentLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.addToBtn = new System.Windows.Forms.Button();
            this.partCb = new System.Windows.Forms.ComboBox();
            this.technicianNoteTb = new System.Windows.Forms.TextBox();
            this.amountTb = new System.Windows.Forms.TextBox();
            this.startDateDtp = new System.Windows.Forms.DateTimePicker();
            this.endDateDtp = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.departmentLbl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.assetNameLbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.assetSNLbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Asset:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.endDateDtp);
            this.groupBox2.Controls.Add(this.startDateDtp);
            this.groupBox2.Controls.Add(this.technicianNoteTb);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(918, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asset EM Report";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.amountTb);
            this.groupBox3.Controls.Add(this.partCb);
            this.groupBox3.Controls.Add(this.addToBtn);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(13, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(918, 243);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Replacement Parts:";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(906, 144);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // submitbtn
            // 
            this.submitbtn.Location = new System.Drawing.Point(396, 551);
            this.submitbtn.Name = "submitbtn";
            this.submitbtn.Size = new System.Drawing.Size(208, 23);
            this.submitbtn.TabIndex = 3;
            this.submitbtn.Text = "Submit";
            this.submitbtn.UseVisualStyleBackColor = true;
            this.submitbtn.Click += new System.EventHandler(this.submitbtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(610, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(315, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset SN:";
            // 
            // assetSNLbl
            // 
            this.assetSNLbl.AutoSize = true;
            this.assetSNLbl.Location = new System.Drawing.Point(94, 41);
            this.assetSNLbl.Name = "assetSNLbl";
            this.assetSNLbl.Size = new System.Drawing.Size(46, 17);
            this.assetSNLbl.TabIndex = 1;
            this.assetSNLbl.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Name:";
            // 
            // assetNameLbl
            // 
            this.assetNameLbl.AutoSize = true;
            this.assetNameLbl.Location = new System.Drawing.Point(303, 41);
            this.assetNameLbl.Name = "assetNameLbl";
            this.assetNameLbl.Size = new System.Drawing.Size(46, 17);
            this.assetNameLbl.TabIndex = 3;
            this.assetNameLbl.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Department:";
            // 
            // departmentLbl
            // 
            this.departmentLbl.AutoSize = true;
            this.departmentLbl.Location = new System.Drawing.Point(528, 41);
            this.departmentLbl.Name = "departmentLbl";
            this.departmentLbl.Size = new System.Drawing.Size(46, 17);
            this.departmentLbl.TabIndex = 5;
            this.departmentLbl.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Start Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(476, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "End Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Technician Note:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Part Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(520, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Amount:";
            // 
            // addToBtn
            // 
            this.addToBtn.Location = new System.Drawing.Point(692, 35);
            this.addToBtn.Name = "addToBtn";
            this.addToBtn.Size = new System.Drawing.Size(208, 23);
            this.addToBtn.TabIndex = 5;
            this.addToBtn.Text = "Add To List +";
            this.addToBtn.UseVisualStyleBackColor = true;
            this.addToBtn.Click += new System.EventHandler(this.addToBtn_Click);
            // 
            // partCb
            // 
            this.partCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partCb.FormattingEnabled = true;
            this.partCb.Location = new System.Drawing.Point(98, 36);
            this.partCb.Name = "partCb";
            this.partCb.Size = new System.Drawing.Size(400, 24);
            this.partCb.TabIndex = 6;
            // 
            // technicianNoteTb
            // 
            this.technicianNoteTb.Location = new System.Drawing.Point(98, 77);
            this.technicianNoteTb.Multiline = true;
            this.technicianNoteTb.Name = "technicianNoteTb";
            this.technicianNoteTb.Size = new System.Drawing.Size(815, 41);
            this.technicianNoteTb.TabIndex = 3;
            this.technicianNoteTb.TextChanged += new System.EventHandler(this.technicianNoteTb_TextChanged);
            // 
            // amountTb
            // 
            this.amountTb.Location = new System.Drawing.Point(586, 36);
            this.amountTb.Name = "amountTb";
            this.amountTb.Size = new System.Drawing.Size(100, 22);
            this.amountTb.TabIndex = 7;
            // 
            // startDateDtp
            // 
            this.startDateDtp.Location = new System.Drawing.Point(98, 31);
            this.startDateDtp.Name = "startDateDtp";
            this.startDateDtp.Size = new System.Drawing.Size(339, 22);
            this.startDateDtp.TabIndex = 4;
            // 
            // endDateDtp
            // 
            this.endDateDtp.Enabled = false;
            this.endDateDtp.Location = new System.Drawing.Point(565, 31);
            this.endDateDtp.Name = "endDateDtp";
            this.endDateDtp.Size = new System.Drawing.Size(335, 22);
            this.endDateDtp.TabIndex = 5;
            // 
            // FormEmergencyMaintenanceRequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 610);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.submitbtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormEmergencyMaintenanceRequestDetails";
            this.Text = "FormEmergencyMaintenanceRequestDetails";
            this.Load += new System.EventHandler(this.FormEmergencyMaintenanceRequestDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label departmentLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label assetNameLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label assetSNLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addToBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker endDateDtp;
        private System.Windows.Forms.DateTimePicker startDateDtp;
        private System.Windows.Forms.TextBox technicianNoteTb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.ComboBox partCb;
    }
}