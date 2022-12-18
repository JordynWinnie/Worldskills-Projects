namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    partial class UpdateSponsorshipBookings
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.packageDGV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.totalValueLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newQty = new System.Windows.Forms.NumericUpDown();
            this.updateQty = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 33;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Update Sponsorship Booking";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(495, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 31;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 57);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // packageDGV
            // 
            this.packageDGV.AllowUserToAddRows = false;
            this.packageDGV.AllowUserToDeleteRows = false;
            this.packageDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packageDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packageDGV.Location = new System.Drawing.Point(10, 98);
            this.packageDGV.Name = "packageDGV";
            this.packageDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.packageDGV.Size = new System.Drawing.Size(776, 323);
            this.packageDGV.TabIndex = 37;
            this.packageDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packageDGV_CellClick);
            this.packageDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packageDGV_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(582, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Total ($):";
            // 
            // totalValueLbl
            // 
            this.totalValueLbl.AutoSize = true;
            this.totalValueLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueLbl.Location = new System.Drawing.Point(659, 442);
            this.totalValueLbl.Name = "totalValueLbl";
            this.totalValueLbl.Size = new System.Drawing.Size(14, 20);
            this.totalValueLbl.TabIndex = 40;
            this.totalValueLbl.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "New Quantity:";
            // 
            // newQty
            // 
            this.newQty.Location = new System.Drawing.Point(423, 518);
            this.newQty.Name = "newQty";
            this.newQty.Size = new System.Drawing.Size(230, 20);
            this.newQty.TabIndex = 42;
            // 
            // updateQty
            // 
            this.updateQty.Location = new System.Drawing.Point(663, 515);
            this.updateQty.Name = "updateQty";
            this.updateQty.Size = new System.Drawing.Size(123, 23);
            this.updateQty.TabIndex = 43;
            this.updateQty.Text = "Update Quantity";
            this.updateQty.UseVisualStyleBackColor = true;
            this.updateQty.Click += new System.EventHandler(this.updateQty_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(663, 563);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(123, 23);
            this.deleteBtn.TabIndex = 44;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 592);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(801, 57);
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // UpdateSponsorshipBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 646);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateQty);
            this.Controls.Add(this.newQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalValueLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.packageDGV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UpdateSponsorshipBookings";
            this.Text = "UpdateSponsorshipBookings";
            this.Load += new System.EventHandler(this.UpdateSponsorshipBookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView packageDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalValueLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown newQty;
        private System.Windows.Forms.Button updateQty;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}