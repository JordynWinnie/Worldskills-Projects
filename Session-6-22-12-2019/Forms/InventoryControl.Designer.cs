namespace Session_6_22_12_2019
{
    partial class InventoryControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.assetnameCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDtp = new System.Windows.Forms.DateTimePicker();
            this.partSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.allocationCB = new System.Windows.Forms.ComboBox();
            this.amountTb = new System.Windows.Forms.TextBox();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.allocateBtn = new System.Windows.Forms.Button();
            this.allocatedPartGroupbox = new System.Windows.Forms.GroupBox();
            this.allocatedPartsDGV = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.assignedPartsDGV = new System.Windows.Forms.DataGridView();
            this.submitBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.stateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.partSearchGroupBox.SuspendLayout();
            this.allocatedPartGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allocatedPartsDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedPartsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Name (EM Number):";
            // 
            // assetnameCB
            // 
            this.assetnameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assetnameCB.FormattingEnabled = true;
            this.assetnameCB.Location = new System.Drawing.Point(151, 12);
            this.assetnameCB.Name = "assetnameCB";
            this.assetnameCB.Size = new System.Drawing.Size(304, 21);
            this.assetnameCB.TabIndex = 1;
            this.assetnameCB.SelectedIndexChanged += new System.EventHandler(this.assetnameCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // dateDtp
            // 
            this.dateDtp.Enabled = false;
            this.dateDtp.Location = new System.Drawing.Point(515, 12);
            this.dateDtp.Name = "dateDtp";
            this.dateDtp.Size = new System.Drawing.Size(200, 20);
            this.dateDtp.TabIndex = 3;
            this.dateDtp.ValueChanged += new System.EventHandler(this.dateDtp_ValueChanged);
            // 
            // partSearchGroupBox
            // 
            this.partSearchGroupBox.Controls.Add(this.allocationCB);
            this.partSearchGroupBox.Controls.Add(this.amountTb);
            this.partSearchGroupBox.Controls.Add(this.partNameCb);
            this.partSearchGroupBox.Controls.Add(this.warehouseCb);
            this.partSearchGroupBox.Controls.Add(this.label6);
            this.partSearchGroupBox.Controls.Add(this.label5);
            this.partSearchGroupBox.Controls.Add(this.label4);
            this.partSearchGroupBox.Controls.Add(this.label3);
            this.partSearchGroupBox.Controls.Add(this.allocateBtn);
            this.partSearchGroupBox.Enabled = false;
            this.partSearchGroupBox.Location = new System.Drawing.Point(12, 60);
            this.partSearchGroupBox.Name = "partSearchGroupBox";
            this.partSearchGroupBox.Size = new System.Drawing.Size(775, 100);
            this.partSearchGroupBox.TabIndex = 4;
            this.partSearchGroupBox.TabStop = false;
            this.partSearchGroupBox.Text = "Search For Parts:";
            // 
            // allocationCB
            // 
            this.allocationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allocationCB.FormattingEnabled = true;
            this.allocationCB.Location = new System.Drawing.Point(429, 17);
            this.allocationCB.Name = "allocationCB";
            this.allocationCB.Size = new System.Drawing.Size(133, 21);
            this.allocationCB.TabIndex = 18;
            this.allocationCB.SelectedIndexChanged += new System.EventHandler(this.allocationCB_SelectedIndexChanged);
            // 
            // amountTb
            // 
            this.amountTb.Location = new System.Drawing.Point(380, 51);
            this.amountTb.Name = "amountTb";
            this.amountTb.Size = new System.Drawing.Size(100, 20);
            this.amountTb.TabIndex = 17;
            this.amountTb.Text = "0";
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(88, 50);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(230, 21);
            this.partNameCb.TabIndex = 16;
            this.partNameCb.SelectedIndexChanged += new System.EventHandler(this.partNameCb_SelectedIndexChanged);
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(88, 17);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(230, 21);
            this.warehouseCb.TabIndex = 15;
            this.warehouseCb.SelectedIndexChanged += new System.EventHandler(this.warehouseCb_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Allocation Method:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Part Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Warehouse:";
            // 
            // allocateBtn
            // 
            this.allocateBtn.Location = new System.Drawing.Point(502, 49);
            this.allocateBtn.Name = "allocateBtn";
            this.allocateBtn.Size = new System.Drawing.Size(267, 23);
            this.allocateBtn.TabIndex = 10;
            this.allocateBtn.Text = "Allocate";
            this.allocateBtn.UseVisualStyleBackColor = true;
            this.allocateBtn.Click += new System.EventHandler(this.allocateBtn_Click);
            // 
            // allocatedPartGroupbox
            // 
            this.allocatedPartGroupbox.Controls.Add(this.allocatedPartsDGV);
            this.allocatedPartGroupbox.Controls.Add(this.button3);
            this.allocatedPartGroupbox.Enabled = false;
            this.allocatedPartGroupbox.Location = new System.Drawing.Point(12, 167);
            this.allocatedPartGroupbox.Name = "allocatedPartGroupbox";
            this.allocatedPartGroupbox.Size = new System.Drawing.Size(775, 142);
            this.allocatedPartGroupbox.TabIndex = 5;
            this.allocatedPartGroupbox.TabStop = false;
            this.allocatedPartGroupbox.Text = "Allocated Parts:";
            this.allocatedPartGroupbox.Enter += new System.EventHandler(this.allocatedPartGroupbox_Enter);
            // 
            // allocatedPartsDGV
            // 
            this.allocatedPartsDGV.AllowUserToAddRows = false;
            this.allocatedPartsDGV.AllowUserToDeleteRows = false;
            this.allocatedPartsDGV.AllowUserToOrderColumns = true;
            this.allocatedPartsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allocatedPartsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allocatedPartsDGV.Location = new System.Drawing.Point(7, 20);
            this.allocatedPartsDGV.Name = "allocatedPartsDGV";
            this.allocatedPartsDGV.Size = new System.Drawing.Size(662, 116);
            this.allocatedPartsDGV.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(675, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "+ Assign to EM";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.assignedPartsDGV);
            this.groupBox3.Location = new System.Drawing.Point(12, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 200);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Assigned Parts";
            // 
            // assignedPartsDGV
            // 
            this.assignedPartsDGV.AllowUserToAddRows = false;
            this.assignedPartsDGV.AllowUserToDeleteRows = false;
            this.assignedPartsDGV.AllowUserToOrderColumns = true;
            this.assignedPartsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assignedPartsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assignedPartsDGV.Location = new System.Drawing.Point(7, 19);
            this.assignedPartsDGV.Name = "assignedPartsDGV";
            this.assignedPartsDGV.Size = new System.Drawing.Size(762, 175);
            this.assignedPartsDGV.TabIndex = 11;
            this.assignedPartsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assignedPartsDGV_CellClick);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(22, 521);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(353, 23);
            this.submitBtn.TabIndex = 7;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(381, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(400, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.ForeColor = System.Drawing.Color.Red;
            this.stateLabel.Location = new System.Drawing.Point(13, 40);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 17);
            this.stateLabel.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "DEBUG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.allocatedPartGroupbox);
            this.Controls.Add(this.partSearchGroupBox);
            this.Controls.Add(this.dateDtp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.assetnameCB);
            this.Controls.Add(this.label1);
            this.Name = "InventoryControl";
            this.Text = "InventoryControl";
            this.Load += new System.EventHandler(this.InventoryControl_Load);
            this.partSearchGroupBox.ResumeLayout(false);
            this.partSearchGroupBox.PerformLayout();
            this.allocatedPartGroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allocatedPartsDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assignedPartsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox assetnameCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.GroupBox partSearchGroupBox;
        private System.Windows.Forms.Button allocateBtn;
        private System.Windows.Forms.GroupBox allocatedPartGroupbox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.ComboBox warehouseCb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox allocationCB;
        private System.Windows.Forms.DataGridView allocatedPartsDGV;
        private System.Windows.Forms.DataGridView assignedPartsDGV;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button button1;
    }
}