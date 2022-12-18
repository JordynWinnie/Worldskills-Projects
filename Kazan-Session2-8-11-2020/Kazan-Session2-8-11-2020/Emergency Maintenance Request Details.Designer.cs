namespace Kazan_Session2_8_11_2020
{
    partial class Emergency_Maintenance_Request_Details
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.Label();
            this.assetName = new System.Windows.Forms.Label();
            this.assetSN = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedAssetGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.technicianNote = new System.Windows.Forms.TextBox();
            this.replacementPartGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.partDGV = new System.Windows.Forms.DataGridView();
            this.amountNUD = new System.Windows.Forms.NumericUpDown();
            this.addToListBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.selectedAssetGroupBox.SuspendLayout();
            this.replacementPartGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Department:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Asset Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Asset SN:";
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department.Location = new System.Drawing.Point(525, 34);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(104, 13);
            this.department.TabIndex = 3;
            this.department.Text = "Available Assets:";
            // 
            // assetName
            // 
            this.assetName.AutoSize = true;
            this.assetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assetName.Location = new System.Drawing.Point(324, 34);
            this.assetName.Name = "assetName";
            this.assetName.Size = new System.Drawing.Size(104, 13);
            this.assetName.TabIndex = 2;
            this.assetName.Text = "Available Assets:";
            // 
            // assetSN
            // 
            this.assetSN.AutoSize = true;
            this.assetSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assetSN.Location = new System.Drawing.Point(107, 34);
            this.assetSN.Name = "assetSN";
            this.assetSN.Size = new System.Drawing.Size(104, 13);
            this.assetSN.TabIndex = 1;
            this.assetSN.Text = "Available Assets:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.department);
            this.groupBox1.Controls.Add(this.assetName);
            this.groupBox1.Controls.Add(this.assetSN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Asset";
            // 
            // selectedAssetGroupBox
            // 
            this.selectedAssetGroupBox.Controls.Add(this.technicianNote);
            this.selectedAssetGroupBox.Controls.Add(this.label4);
            this.selectedAssetGroupBox.Controls.Add(this.endDate);
            this.selectedAssetGroupBox.Controls.Add(this.startDate);
            this.selectedAssetGroupBox.Controls.Add(this.label5);
            this.selectedAssetGroupBox.Controls.Add(this.label6);
            this.selectedAssetGroupBox.Location = new System.Drawing.Point(13, 93);
            this.selectedAssetGroupBox.Name = "selectedAssetGroupBox";
            this.selectedAssetGroupBox.Size = new System.Drawing.Size(775, 146);
            this.selectedAssetGroupBox.TabIndex = 7;
            this.selectedAssetGroupBox.TabStop = false;
            this.selectedAssetGroupBox.Text = "Em Report:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Completed On:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Start Date:";
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(79, 34);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 6;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(368, 34);
            this.endDate.Name = "endDate";
            this.endDate.ShowCheckBox = true;
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Technician Note:";
            // 
            // technicianNote
            // 
            this.technicianNote.Location = new System.Drawing.Point(79, 81);
            this.technicianNote.Multiline = true;
            this.technicianNote.Name = "technicianNote";
            this.technicianNote.Size = new System.Drawing.Size(690, 42);
            this.technicianNote.TabIndex = 9;
            // 
            // replacementPartGroupBox
            // 
            this.replacementPartGroupBox.Controls.Add(this.addToListBtn);
            this.replacementPartGroupBox.Controls.Add(this.amountNUD);
            this.replacementPartGroupBox.Controls.Add(this.partDGV);
            this.replacementPartGroupBox.Controls.Add(this.partNameCb);
            this.replacementPartGroupBox.Controls.Add(this.label7);
            this.replacementPartGroupBox.Controls.Add(this.label8);
            this.replacementPartGroupBox.Controls.Add(this.label9);
            this.replacementPartGroupBox.Location = new System.Drawing.Point(13, 256);
            this.replacementPartGroupBox.Name = "replacementPartGroupBox";
            this.replacementPartGroupBox.Size = new System.Drawing.Size(775, 332);
            this.replacementPartGroupBox.TabIndex = 10;
            this.replacementPartGroupBox.TabStop = false;
            this.replacementPartGroupBox.Text = "Replacement Parts:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Part List:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Amount:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Part Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(381, 609);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(89, 34);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(324, 21);
            this.partNameCb.TabIndex = 10;
            // 
            // partDGV
            // 
            this.partDGV.AllowUserToAddRows = false;
            this.partDGV.AllowUserToDeleteRows = false;
            this.partDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partDGV.Location = new System.Drawing.Point(18, 92);
            this.partDGV.Name = "partDGV";
            this.partDGV.Size = new System.Drawing.Size(751, 224);
            this.partDGV.TabIndex = 11;
            this.partDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partDGV_CellClick);
            // 
            // amountNUD
            // 
            this.amountNUD.DecimalPlaces = 2;
            this.amountNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.amountNUD.Location = new System.Drawing.Point(471, 34);
            this.amountNUD.Name = "amountNUD";
            this.amountNUD.Size = new System.Drawing.Size(120, 20);
            this.amountNUD.TabIndex = 12;
            // 
            // addToListBtn
            // 
            this.addToListBtn.Location = new System.Drawing.Point(641, 31);
            this.addToListBtn.Name = "addToListBtn";
            this.addToListBtn.Size = new System.Drawing.Size(75, 23);
            this.addToListBtn.TabIndex = 13;
            this.addToListBtn.Text = "Add To List";
            this.addToListBtn.UseVisualStyleBackColor = true;
            this.addToListBtn.Click += new System.EventHandler(this.addToListBtn_Click);
            // 
            // Emergency_Maintenance_Request_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 644);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.replacementPartGroupBox);
            this.Controls.Add(this.selectedAssetGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Emergency_Maintenance_Request_Details";
            this.Text = "Emergency_Maintenance_Request_Details";
            this.Load += new System.EventHandler(this.Emergency_Maintenance_Request_Details_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.selectedAssetGroupBox.ResumeLayout(false);
            this.selectedAssetGroupBox.PerformLayout();
            this.replacementPartGroupBox.ResumeLayout(false);
            this.replacementPartGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label department;
        private System.Windows.Forms.Label assetName;
        private System.Windows.Forms.Label assetSN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox selectedAssetGroupBox;
        private System.Windows.Forms.TextBox technicianNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox replacementPartGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView partDGV;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.Button addToListBtn;
        private System.Windows.Forms.NumericUpDown amountNUD;
    }
}