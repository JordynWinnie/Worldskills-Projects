namespace Session4_12_10_2019
{
    partial class EditPurchaseOrders
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
            this.label3 = new System.Windows.Forms.Label();
            this.supplierCb = new System.Windows.Forms.ComboBox();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.purchaseDateDtp = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partsListDGV = new System.Windows.Forms.DataGridView();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbBatchNo = new System.Windows.Forms.TextBox();
            this.partsNameCb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suppliers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Warehouse:";
            // 
            // supplierCb
            // 
            this.supplierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierCb.FormattingEnabled = true;
            this.supplierCb.Location = new System.Drawing.Point(15, 30);
            this.supplierCb.Name = "supplierCb";
            this.supplierCb.Size = new System.Drawing.Size(252, 24);
            this.supplierCb.TabIndex = 3;
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(294, 30);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(252, 24);
            this.warehouseCb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date:";
            // 
            // purchaseDateDtp
            // 
            this.purchaseDateDtp.Location = new System.Drawing.Point(67, 71);
            this.purchaseDateDtp.Name = "purchaseDateDtp";
            this.purchaseDateDtp.Size = new System.Drawing.Size(479, 22);
            this.purchaseDateDtp.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.partsListDGV);
            this.groupBox1.Controls.Add(this.btnAddToList);
            this.groupBox1.Controls.Add(this.tbAmount);
            this.groupBox1.Controls.Add(this.tbBatchNo);
            this.groupBox1.Controls.Add(this.partsNameCb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(18, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1091, 278);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // partsListDGV
            // 
            this.partsListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsListDGV.Location = new System.Drawing.Point(6, 66);
            this.partsListDGV.Name = "partsListDGV";
            this.partsListDGV.RowHeadersWidth = 51;
            this.partsListDGV.RowTemplate.Height = 24;
            this.partsListDGV.Size = new System.Drawing.Size(1079, 206);
            this.partsListDGV.TabIndex = 12;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(820, 23);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(265, 23);
            this.btnAddToList.TabIndex = 11;
            this.btnAddToList.Text = "+ Add To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(623, 25);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(180, 22);
            this.tbAmount.TabIndex = 10;
            // 
            // tbBatchNo
            // 
            this.tbBatchNo.Location = new System.Drawing.Point(371, 25);
            this.tbBatchNo.Name = "tbBatchNo";
            this.tbBatchNo.Size = new System.Drawing.Size(180, 22);
            this.tbBatchNo.TabIndex = 9;
            // 
            // partsNameCb
            // 
            this.partsNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partsNameCb.FormattingEnabled = true;
            this.partsNameCb.Location = new System.Drawing.Point(114, 25);
            this.partsNameCb.Name = "partsNameCb";
            this.partsNameCb.Size = new System.Drawing.Size(135, 24);
            this.partsNameCb.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Batch Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Parts Name:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(449, 415);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(530, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(968, 388);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(135, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "[DEBUG] Print All Items";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1115, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "label7";
            // 
            // EditPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.purchaseDateDtp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.warehouseCb);
            this.Controls.Add(this.supplierCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "EditPurchaseOrders";
            this.Text = "Edit OR Purchase";
            this.Load += new System.EventHandler(this.EditPurchaseOrders_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox supplierCb;
        private System.Windows.Forms.ComboBox warehouseCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker purchaseDateDtp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView partsListDGV;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbBatchNo;
        private System.Windows.Forms.ComboBox partsNameCb;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}