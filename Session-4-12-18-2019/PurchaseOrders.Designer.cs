namespace Session_4_12_18_2019
{
    partial class PurchaseOrders
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
            this.dateDtp = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.amountTb = new System.Windows.Forms.TextBox();
            this.batchnotb = new System.Windows.Forms.TextBox();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.partsListDGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.supplierCb = new System.Windows.Forms.ComboBox();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
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
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suppliers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Warehouses:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date:";
            // 
            // dateDtp
            // 
            this.dateDtp.Location = new System.Drawing.Point(46, 66);
            this.dateDtp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateDtp.Name = "dateDtp";
            this.dateDtp.Size = new System.Drawing.Size(320, 20);
            this.dateDtp.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.amountTb);
            this.groupBox1.Controls.Add(this.batchnotb);
            this.groupBox1.Controls.Add(this.partNameCb);
            this.groupBox1.Controls.Add(this.partsListDGV);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(10, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(854, 283);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // amountTb
            // 
            this.amountTb.Location = new System.Drawing.Point(464, 26);
            this.amountTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.amountTb.Name = "amountTb";
            this.amountTb.Size = new System.Drawing.Size(117, 20);
            this.amountTb.TabIndex = 7;
            this.amountTb.Text = "0";
            // 
            // batchnotb
            // 
            this.batchnotb.Location = new System.Drawing.Point(259, 25);
            this.batchnotb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.batchnotb.Name = "batchnotb";
            this.batchnotb.Size = new System.Drawing.Size(98, 20);
            this.batchnotb.TabIndex = 6;
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(69, 25);
            this.partNameCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(92, 21);
            this.partNameCb.TabIndex = 5;
            // 
            // partsListDGV
            // 
            this.partsListDGV.AllowUserToAddRows = false;
            this.partsListDGV.AllowUserToDeleteRows = false;
            this.partsListDGV.AllowUserToOrderColumns = true;
            this.partsListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsListDGV.Location = new System.Drawing.Point(8, 61);
            this.partsListDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.partsListDGV.Name = "partsListDGV";
            this.partsListDGV.RowHeadersWidth = 51;
            this.partsListDGV.RowTemplate.Height = 24;
            this.partsListDGV.Size = new System.Drawing.Size(842, 217);
            this.partsListDGV.TabIndex = 4;
            this.partsListDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsListDGV_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "+ Add To List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Batch Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part Name:";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(10, 376);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(434, 38);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(448, 376);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(412, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // supplierCb
            // 
            this.supplierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierCb.FormattingEnabled = true;
            this.supplierCb.Location = new System.Drawing.Point(12, 27);
            this.supplierCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.supplierCb.Name = "supplierCb";
            this.supplierCb.Size = new System.Drawing.Size(349, 21);
            this.supplierCb.TabIndex = 8;
            this.supplierCb.SelectedIndexChanged += new System.EventHandler(this.supplierCb_SelectedIndexChanged);
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(364, 27);
            this.warehouseCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(352, 21);
            this.warehouseCb.TabIndex = 9;
            // 
            // PurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 425);
            this.Controls.Add(this.warehouseCb);
            this.Controls.Add(this.supplierCb);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateDtp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PurchaseOrders";
            this.Text = "PurchaseOrders";
            this.Load += new System.EventHandler(this.PurchaseOrders_Load);
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
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView partsListDGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox batchnotb;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox supplierCb;
        private System.Windows.Forms.ComboBox warehouseCb;
    }
}