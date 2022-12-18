namespace TPQR_Session3_9_8_2020
{
    partial class AdminMainMenuForm
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
            this.updateInfoBtn = new System.Windows.Forms.Button();
            this.hotelBookingBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.arrSummary = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // updateInfoBtn
            // 
            this.updateInfoBtn.Location = new System.Drawing.Point(263, 232);
            this.updateInfoBtn.Name = "updateInfoBtn";
            this.updateInfoBtn.Size = new System.Drawing.Size(255, 41);
            this.updateInfoBtn.TabIndex = 33;
            this.updateInfoBtn.Text = "Guest Summary";
            this.updateInfoBtn.UseVisualStyleBackColor = true;
            this.updateInfoBtn.Click += new System.EventHandler(this.updateInfoBtn_Click);
            // 
            // hotelBookingBtn
            // 
            this.hotelBookingBtn.Location = new System.Drawing.Point(263, 185);
            this.hotelBookingBtn.Name = "hotelBookingBtn";
            this.hotelBookingBtn.Size = new System.Drawing.Size(255, 41);
            this.hotelBookingBtn.TabIndex = 32;
            this.hotelBookingBtn.Text = "Hotel Summary";
            this.hotelBookingBtn.UseVisualStyleBackColor = true;
            this.hotelBookingBtn.Click += new System.EventHandler(this.hotelBookingBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(288, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 29);
            this.label4.TabIndex = 31;
            this.label4.Text = "Admin Main Menu\r\n";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(151, 29);
            this.backBtn.TabIndex = 30;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // arrSummary
            // 
            this.arrSummary.Location = new System.Drawing.Point(263, 138);
            this.arrSummary.Name = "arrSummary";
            this.arrSummary.Size = new System.Drawing.Size(255, 41);
            this.arrSummary.TabIndex = 29;
            this.arrSummary.Text = "Arrival Summary";
            this.arrSummary.UseVisualStyleBackColor = true;
            this.arrSummary.Click += new System.EventHandler(this.arrSummary_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(531, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 28;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(1, 367);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(798, 85);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 60);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // AdminMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateInfoBtn);
            this.Controls.Add(this.hotelBookingBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.arrSummary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AdminMainMenuForm";
            this.Text = "AdminMainMenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateInfoBtn;
        private System.Windows.Forms.Button hotelBookingBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button arrSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}