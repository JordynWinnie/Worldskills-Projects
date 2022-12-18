namespace TP_QR_Paper3_7_19_2020
{
    partial class CountryRepMainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.confirmArrivalDetails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hotelBookingBtn = new System.Windows.Forms.Button();
            this.updateInfoBooking = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(544, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // confirmArrivalDetails
            // 
            this.confirmArrivalDetails.Location = new System.Drawing.Point(258, 151);
            this.confirmArrivalDetails.Name = "confirmArrivalDetails";
            this.confirmArrivalDetails.Size = new System.Drawing.Size(274, 34);
            this.confirmArrivalDetails.TabIndex = 16;
            this.confirmArrivalDetails.Text = "Confirm Arrival Details";
            this.confirmArrivalDetails.UseVisualStyleBackColor = true;
            this.confirmArrivalDetails.Click += new System.EventHandler(this.createAccountBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "Country Representative Main Menu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // hotelBookingBtn
            // 
            this.hotelBookingBtn.Location = new System.Drawing.Point(258, 206);
            this.hotelBookingBtn.Name = "hotelBookingBtn";
            this.hotelBookingBtn.Size = new System.Drawing.Size(274, 34);
            this.hotelBookingBtn.TabIndex = 17;
            this.hotelBookingBtn.Text = "Hotel Booking";
            this.hotelBookingBtn.UseVisualStyleBackColor = true;
            this.hotelBookingBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // updateInfoBooking
            // 
            this.updateInfoBooking.Location = new System.Drawing.Point(258, 262);
            this.updateInfoBooking.Name = "updateInfoBooking";
            this.updateInfoBooking.Size = new System.Drawing.Size(274, 34);
            this.updateInfoBooking.TabIndex = 18;
            this.updateInfoBooking.Text = "Update Info/Booking";
            this.updateInfoBooking.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 394);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(801, 57);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 62);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CountryRepMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateInfoBooking);
            this.Controls.Add(this.hotelBookingBtn);
            this.Controls.Add(this.confirmArrivalDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CountryRepMainMenu";
            this.Text = "CountryRepMainMenu";
            this.Load += new System.EventHandler(this.CountryRepMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button confirmArrivalDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hotelBookingBtn;
        private System.Windows.Forms.Button updateInfoBooking;
    }
}