namespace Session_4_12_18_2019
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
            this.purchaseOrderMgBtn = new System.Windows.Forms.Button();
            this.warehouseMngBtn = new System.Windows.Forms.Button();
            this.inventReportBtn = new System.Windows.Forms.Button();
            this.currentInventoryDGV = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.currentInventoryDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // purchaseOrderMgBtn
            // 
            this.purchaseOrderMgBtn.Location = new System.Drawing.Point(10, 11);
            this.purchaseOrderMgBtn.Margin = new System.Windows.Forms.Padding(2);
            this.purchaseOrderMgBtn.Name = "purchaseOrderMgBtn";
            this.purchaseOrderMgBtn.Size = new System.Drawing.Size(160, 30);
            this.purchaseOrderMgBtn.TabIndex = 0;
            this.purchaseOrderMgBtn.Text = "Purchase Order Management";
            this.purchaseOrderMgBtn.UseVisualStyleBackColor = true;
            this.purchaseOrderMgBtn.Click += new System.EventHandler(this.purchaseOrderMgBtn_Click);
            // 
            // warehouseMngBtn
            // 
            this.warehouseMngBtn.Location = new System.Drawing.Point(174, 11);
            this.warehouseMngBtn.Margin = new System.Windows.Forms.Padding(2);
            this.warehouseMngBtn.Name = "warehouseMngBtn";
            this.warehouseMngBtn.Size = new System.Drawing.Size(160, 30);
            this.warehouseMngBtn.TabIndex = 1;
            this.warehouseMngBtn.Text = "Warehouse Management";
            this.warehouseMngBtn.UseVisualStyleBackColor = true;
            this.warehouseMngBtn.Click += new System.EventHandler(this.warehouseMngBtn_Click);
            // 
            // inventReportBtn
            // 
            this.inventReportBtn.Location = new System.Drawing.Point(338, 10);
            this.inventReportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.inventReportBtn.Name = "inventReportBtn";
            this.inventReportBtn.Size = new System.Drawing.Size(160, 30);
            this.inventReportBtn.TabIndex = 2;
            this.inventReportBtn.Text = "Inventory Report";
            this.inventReportBtn.UseVisualStyleBackColor = true;
            this.inventReportBtn.Click += new System.EventHandler(this.inventReportBtn_Click);
            // 
            // currentInventoryDGV
            // 
            this.currentInventoryDGV.AllowUserToAddRows = false;
            this.currentInventoryDGV.AllowUserToDeleteRows = false;
            this.currentInventoryDGV.AllowUserToOrderColumns = true;
            this.currentInventoryDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentInventoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentInventoryDGV.Location = new System.Drawing.Point(10, 46);
            this.currentInventoryDGV.Margin = new System.Windows.Forms.Padding(2);
            this.currentInventoryDGV.Name = "currentInventoryDGV";
            this.currentInventoryDGV.RowHeadersWidth = 51;
            this.currentInventoryDGV.RowTemplate.Height = 24;
            this.currentInventoryDGV.Size = new System.Drawing.Size(906, 369);
            this.currentInventoryDGV.TabIndex = 3;
            this.currentInventoryDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.currentInventoryDGV_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(524, 432);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Purchase Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(719, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Warehouse Managment";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(688, 432);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 469);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.currentInventoryDGV);
            this.Controls.Add(this.inventReportBtn);
            this.Controls.Add(this.warehouseMngBtn);
            this.Controls.Add(this.purchaseOrderMgBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentInventoryDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button purchaseOrderMgBtn;
        private System.Windows.Forms.Button warehouseMngBtn;
        private System.Windows.Forms.Button inventReportBtn;
        private System.Windows.Forms.DataGridView currentInventoryDGV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

