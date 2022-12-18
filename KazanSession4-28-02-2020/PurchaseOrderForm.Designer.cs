namespace KazanSession4_28_02_2020
{
    partial class PurchaseOrderForm
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
            this.supplierNameCb = new System.Windows.Forms.ComboBox();
            this.warehouseNameCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDP = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addToListBtn = new System.Windows.Forms.Button();
            this.partsListDGV = new System.Windows.Forms.DataGridView();
            this.partNameCb = new System.Windows.Forms.ComboBox();
            this.batchNoTb = new System.Windows.Forms.TextBox();
            this.amountTb = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Warehouse:";
            // 
            // supplierNameCb
            // 
            this.supplierNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierNameCb.FormattingEnabled = true;
            this.supplierNameCb.Location = new System.Drawing.Point(15, 30);
            this.supplierNameCb.Name = "supplierNameCb";
            this.supplierNameCb.Size = new System.Drawing.Size(286, 24);
            this.supplierNameCb.TabIndex = 2;
            // 
            // warehouseNameCb
            // 
            this.warehouseNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseNameCb.FormattingEnabled = true;
            this.warehouseNameCb.Location = new System.Drawing.Point(369, 28);
            this.warehouseNameCb.Name = "warehouseNameCb";
            this.warehouseNameCb.Size = new System.Drawing.Size(286, 24);
            this.warehouseNameCb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date:";
            // 
            // dateDP
            // 
            this.dateDP.Location = new System.Drawing.Point(18, 97);
            this.dateDP.Name = "dateDP";
            this.dateDP.Size = new System.Drawing.Size(283, 22);
            this.dateDP.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.amountTb);
            this.groupBox1.Controls.Add(this.batchNoTb);
            this.groupBox1.Controls.Add(this.partNameCb);
            this.groupBox1.Controls.Add(this.partsListDGV);
            this.groupBox1.Controls.Add(this.addToListBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(18, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 361);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Part Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Batch Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Amount:";
            // 
            // addToListBtn
            // 
            this.addToListBtn.Location = new System.Drawing.Point(792, 27);
            this.addToListBtn.Name = "addToListBtn";
            this.addToListBtn.Size = new System.Drawing.Size(130, 23);
            this.addToListBtn.TabIndex = 10;
            this.addToListBtn.Text = "+ Add To List";
            this.addToListBtn.UseVisualStyleBackColor = true;
            this.addToListBtn.Click += new System.EventHandler(this.addToListBtn_Click);
            // 
            // partsListDGV
            // 
            this.partsListDGV.AllowUserToAddRows = false;
            this.partsListDGV.AllowUserToDeleteRows = false;
            this.partsListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsListDGV.Location = new System.Drawing.Point(6, 68);
            this.partsListDGV.Name = "partsListDGV";
            this.partsListDGV.RowHeadersWidth = 51;
            this.partsListDGV.RowTemplate.Height = 24;
            this.partsListDGV.Size = new System.Drawing.Size(916, 287);
            this.partsListDGV.TabIndex = 11;
            this.partsListDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsListDGV_CellClick);
            // 
            // partNameCb
            // 
            this.partNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partNameCb.FormattingEnabled = true;
            this.partNameCb.Location = new System.Drawing.Point(105, 27);
            this.partNameCb.Name = "partNameCb";
            this.partNameCb.Size = new System.Drawing.Size(237, 24);
            this.partNameCb.TabIndex = 7;
            // 
            // batchNoTb
            // 
            this.batchNoTb.Location = new System.Drawing.Point(456, 24);
            this.batchNoTb.Name = "batchNoTb";
            this.batchNoTb.Size = new System.Drawing.Size(133, 22);
            this.batchNoTb.TabIndex = 12;
            // 
            // amountTb
            // 
            this.amountTb.Location = new System.Drawing.Point(661, 27);
            this.amountTb.Name = "amountTb";
            this.amountTb.Size = new System.Drawing.Size(125, 22);
            this.amountTb.TabIndex = 13;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(287, 501);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(166, 31);
            this.submitBtn.TabIndex = 7;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(524, 501);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(182, 31);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // PurchaseOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 544);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateDP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.warehouseNameCb);
            this.Controls.Add(this.supplierNameCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseOrderForm";
            this.Text = "PurchaseOrderForm";
            this.Load += new System.EventHandler(this.PurchaseOrderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox supplierNameCb;
        private System.Windows.Forms.ComboBox warehouseNameCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView partsListDGV;
        private System.Windows.Forms.Button addToListBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox partNameCb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox batchNoTb;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}