namespace TPQR_Session2_9_7_2020
{
    partial class UpdateSponsorshipBookingsForm
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.packagesDGV = new System.Windows.Forms.DataGridView();
            this.totalValLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.qtyNUD = new System.Windows.Forms.NumericUpDown();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(11, 6);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(145, 38);
            this.backBtn.TabIndex = 50;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(220, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 29);
            this.label2.TabIndex = 49;
            this.label2.Text = "Update Sponsorship Bookings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(530, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 48;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(1, 531);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(796, 77);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(1, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(796, 62);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // packagesDGV
            // 
            this.packagesDGV.AllowUserToAddRows = false;
            this.packagesDGV.AllowUserToDeleteRows = false;
            this.packagesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packagesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packagesDGV.Location = new System.Drawing.Point(12, 129);
            this.packagesDGV.Name = "packagesDGV";
            this.packagesDGV.RowHeadersWidth = 51;
            this.packagesDGV.RowTemplate.Height = 24;
            this.packagesDGV.Size = new System.Drawing.Size(775, 228);
            this.packagesDGV.TabIndex = 51;
            this.packagesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packagesDGV_CellClick);
            this.packagesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packagesDGV_CellContentClick);
            // 
            // totalValLbl
            // 
            this.totalValLbl.AutoSize = true;
            this.totalValLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValLbl.Location = new System.Drawing.Point(556, 380);
            this.totalValLbl.Name = "totalValLbl";
            this.totalValLbl.Size = new System.Drawing.Size(232, 29);
            this.totalValLbl.TabIndex = 52;
            this.totalValLbl.Text = "Total Value: <value>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 29);
            this.label3.TabIndex = 53;
            this.label3.Text = "New Quantity:";
            // 
            // qtyNUD
            // 
            this.qtyNUD.Location = new System.Drawing.Point(485, 444);
            this.qtyNUD.Name = "qtyNUD";
            this.qtyNUD.Size = new System.Drawing.Size(166, 22);
            this.qtyNUD.TabIndex = 54;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(657, 435);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(130, 38);
            this.updateBtn.TabIndex = 55;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(657, 487);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(130, 38);
            this.deleteBtn.TabIndex = 56;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // UpdateSponsorshipBookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 608);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.qtyNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalValLbl);
            this.Controls.Add(this.packagesDGV);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UpdateSponsorshipBookingsForm";
            this.Text = "UpdateSponsorshipBookingsForm";
            this.Load += new System.EventHandler(this.UpdateSponsorshipBookingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView packagesDGV;
        private System.Windows.Forms.Label totalValLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown qtyNUD;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}