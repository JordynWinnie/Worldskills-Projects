namespace WSC2019Kazan_S6_05272022_Windows_NetFramework
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
            this.label2 = new System.Windows.Forms.Label();
            this.currentlySelectedDate = new System.Windows.Forms.DateTimePicker();
            this.assetEMCb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.allocMethodCb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.amountUpDown = new System.Windows.Forms.NumericUpDown();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.allocatedPartsDGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.assignedPartsDGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allocatedPartsDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedPartsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Name (EM Number):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date:";
            // 
            // currentlySelectedDate
            // 
            this.currentlySelectedDate.Location = new System.Drawing.Point(398, 14);
            this.currentlySelectedDate.Margin = new System.Windows.Forms.Padding(2);
            this.currentlySelectedDate.Name = "currentlySelectedDate";
            this.currentlySelectedDate.Size = new System.Drawing.Size(194, 20);
            this.currentlySelectedDate.TabIndex = 2;
            this.currentlySelectedDate.ValueChanged += new System.EventHandler(this.currentlySelectedDate_ValueChanged);
            // 
            // assetEMCb
            // 
            this.assetEMCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assetEMCb.FormattingEnabled = true;
            this.assetEMCb.Location = new System.Drawing.Point(138, 12);
            this.assetEMCb.Margin = new System.Windows.Forms.Padding(2);
            this.assetEMCb.Name = "assetEMCb";
            this.assetEMCb.Size = new System.Drawing.Size(223, 21);
            this.assetEMCb.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.allocMethodCb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.amountUpDown);
            this.groupBox1.Controls.Add(this.partNameCb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.warehouseCb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(706, 96);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search For Parts";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(585, 59);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 19);
            this.button3.TabIndex = 17;
            this.button3.Text = "Allocate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // allocMethodCb
            // 
            this.allocMethodCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allocMethodCb.FormattingEnabled = true;
            this.allocMethodCb.Location = new System.Drawing.Point(383, 59);
            this.allocMethodCb.Margin = new System.Windows.Forms.Padding(2);
            this.allocMethodCb.Name = "allocMethodCb";
            this.allocMethodCb.Size = new System.Drawing.Size(198, 21);
            this.allocMethodCb.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Allocation Method:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Amount:";
            // 
            // amountUpDown
            // 
            this.amountUpDown.Location = new System.Drawing.Point(345, 20);
            this.amountUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.amountUpDown.Name = "amountUpDown";
            this.amountUpDown.Size = new System.Drawing.Size(92, 20);
            this.amountUpDown.TabIndex = 13;
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(76, 57);
            this.partNameCb.Margin = new System.Windows.Forms.Padding(2);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(178, 21);
            this.partNameCb.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Part Name:";
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(76, 20);
            this.warehouseCb.Margin = new System.Windows.Forms.Padding(2);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(178, 21);
            this.warehouseCb.TabIndex = 10;
            this.warehouseCb.SelectedIndexChanged += new System.EventHandler(this.warehouseCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Warehouse:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.allocatedPartsDGV);
            this.groupBox2.Location = new System.Drawing.Point(11, 137);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(706, 154);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allocated Parts";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(585, 120);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 19);
            this.button4.TabIndex = 1;
            this.button4.Text = "Assign to EM";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // allocatedPartsDGV
            // 
            this.allocatedPartsDGV.AllowUserToAddRows = false;
            this.allocatedPartsDGV.AllowUserToDeleteRows = false;
            this.allocatedPartsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allocatedPartsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allocatedPartsDGV.Location = new System.Drawing.Point(14, 18);
            this.allocatedPartsDGV.Margin = new System.Windows.Forms.Padding(2);
            this.allocatedPartsDGV.Name = "allocatedPartsDGV";
            this.allocatedPartsDGV.RowHeadersWidth = 51;
            this.allocatedPartsDGV.RowTemplate.Height = 24;
            this.allocatedPartsDGV.Size = new System.Drawing.Size(566, 122);
            this.allocatedPartsDGV.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.assignedPartsDGV);
            this.groupBox3.Location = new System.Drawing.Point(11, 296);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(706, 217);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Assigned Parts";
            // 
            // assignedPartsDGV
            // 
            this.assignedPartsDGV.AllowUserToAddRows = false;
            this.assignedPartsDGV.AllowUserToDeleteRows = false;
            this.assignedPartsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assignedPartsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assignedPartsDGV.Location = new System.Drawing.Point(14, 17);
            this.assignedPartsDGV.Margin = new System.Windows.Forms.Padding(2);
            this.assignedPartsDGV.Name = "assignedPartsDGV";
            this.assignedPartsDGV.RowHeadersWidth = 51;
            this.assignedPartsDGV.RowTemplate.Height = 24;
            this.assignedPartsDGV.Size = new System.Drawing.Size(676, 195);
            this.assignedPartsDGV.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 518);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 19);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(636, 518);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 19);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // InventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 557);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.assetEMCb);
            this.Controls.Add(this.currentlySelectedDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryControl";
            this.Text = "Inventory Control";
            this.Load += new System.EventHandler(this.InventoryControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allocatedPartsDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assignedPartsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker currentlySelectedDate;
        private System.Windows.Forms.ComboBox assetEMCb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox warehouseCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown amountUpDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox allocMethodCb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView allocatedPartsDGV;
        private System.Windows.Forms.DataGridView assignedPartsDGV;
    }
}