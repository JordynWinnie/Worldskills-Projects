namespace Session_4_12_18_2019
{
    partial class WarehouseManagement
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.batchNumberCb = new System.Windows.Forms.ComboBox();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.partsListDGV = new System.Windows.Forms.DataGridView();
            this.amountTb = new System.Windows.Forms.TextBox();
            this.addToListBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.destinationWarehouseCb = new System.Windows.Forms.ComboBox();
            this.sourceWarehouseCb = new System.Windows.Forms.ComboBox();
            this.dateDtp = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Warehouse:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Warehouse:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parts Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Batch Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(521, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.batchNumberCb);
            this.groupBox1.Controls.Add(this.partNameCb);
            this.groupBox1.Controls.Add(this.partsListDGV);
            this.groupBox1.Controls.Add(this.amountTb);
            this.groupBox1.Controls.Add(this.addToListBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(790, 233);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // batchNumberCb
            // 
            this.batchNumberCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchNumberCb.FormattingEnabled = true;
            this.batchNumberCb.Location = new System.Drawing.Point(410, 28);
            this.batchNumberCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.batchNumberCb.Name = "batchNumberCb";
            this.batchNumberCb.Size = new System.Drawing.Size(108, 21);
            this.batchNumberCb.TabIndex = 9;
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(74, 24);
            this.partNameCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(239, 21);
            this.partNameCb.TabIndex = 8;
            this.partNameCb.SelectedIndexChanged += new System.EventHandler(this.partNameCb_SelectedIndexChanged);
            // 
            // partsListDGV
            // 
            this.partsListDGV.AllowUserToAddRows = false;
            this.partsListDGV.AllowUserToDeleteRows = false;
            this.partsListDGV.AllowUserToOrderColumns = true;
            this.partsListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsListDGV.Location = new System.Drawing.Point(7, 67);
            this.partsListDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.partsListDGV.Name = "partsListDGV";
            this.partsListDGV.RowHeadersWidth = 51;
            this.partsListDGV.RowTemplate.Height = 24;
            this.partsListDGV.Size = new System.Drawing.Size(778, 162);
            this.partsListDGV.TabIndex = 7;
            this.partsListDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsListDGV_CellClick);
            // 
            // amountTb
            // 
            this.amountTb.Location = new System.Drawing.Point(571, 26);
            this.amountTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.amountTb.Name = "amountTb";
            this.amountTb.Size = new System.Drawing.Size(76, 20);
            this.amountTb.TabIndex = 9;
            // 
            // addToListBtn
            // 
            this.addToListBtn.Location = new System.Drawing.Point(667, 17);
            this.addToListBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addToListBtn.Name = "addToListBtn";
            this.addToListBtn.Size = new System.Drawing.Size(118, 36);
            this.addToListBtn.TabIndex = 6;
            this.addToListBtn.Text = "+ Add To List";
            this.addToListBtn.UseVisualStyleBackColor = true;
            this.addToListBtn.Click += new System.EventHandler(this.addToListBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(13, 327);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(394, 29);
            this.submitBtn.TabIndex = 7;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(411, 327);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(386, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // destinationWarehouseCb
            // 
            this.destinationWarehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationWarehouseCb.FormattingEnabled = true;
            this.destinationWarehouseCb.Location = new System.Drawing.Point(234, 37);
            this.destinationWarehouseCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.destinationWarehouseCb.Name = "destinationWarehouseCb";
            this.destinationWarehouseCb.Size = new System.Drawing.Size(218, 21);
            this.destinationWarehouseCb.TabIndex = 10;
            this.destinationWarehouseCb.SelectedIndexChanged += new System.EventHandler(this.destinationWarehouseCb_SelectedIndexChanged);
            // 
            // sourceWarehouseCb
            // 
            this.sourceWarehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceWarehouseCb.FormattingEnabled = true;
            this.sourceWarehouseCb.Location = new System.Drawing.Point(12, 37);
            this.sourceWarehouseCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sourceWarehouseCb.Name = "sourceWarehouseCb";
            this.sourceWarehouseCb.Size = new System.Drawing.Size(218, 21);
            this.sourceWarehouseCb.TabIndex = 11;
            this.sourceWarehouseCb.SelectedIndexChanged += new System.EventHandler(this.sourceWarehouseCb_SelectedIndexChanged);
            // 
            // dateDtp
            // 
            this.dateDtp.Location = new System.Drawing.Point(45, 67);
            this.dateDtp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateDtp.Name = "dateDtp";
            this.dateDtp.Size = new System.Drawing.Size(408, 20);
            this.dateDtp.TabIndex = 12;
            // 
            // WarehouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 366);
            this.Controls.Add(this.dateDtp);
            this.Controls.Add(this.destinationWarehouseCb);
            this.Controls.Add(this.sourceWarehouseCb);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WarehouseManagement";
            this.Text = "WarehouseManagement";
            this.Load += new System.EventHandler(this.WarehouseManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView partsListDGV;
        private System.Windows.Forms.Button addToListBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox batchNumberCb;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.ComboBox destinationWarehouseCb;
        private System.Windows.Forms.ComboBox sourceWarehouseCb;
        private System.Windows.Forms.DateTimePicker dateDtp;
    }
}