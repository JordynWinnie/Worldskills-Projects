﻿namespace Session3_Jordan_Khong
{
    partial class CountryRepMainMenuForm
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
            this.components = new System.ComponentModel.Container();
            this.backBtn = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.hotelBookingBtn = new System.Windows.Forms.Button();
            this.confirmArrivalBtn = new System.Windows.Forms.Button();
            this.UpdateBookingBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(22, 24);
            this.backBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(121, 37);
            this.backBtn.TabIndex = 20;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.Red;
            this.timerLabel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(532, 425);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(48, 17);
            this.timerLabel.TabIndex = 19;
            this.timerLabel.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(497, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(0, 405);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(725, 52);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 80);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(170, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(399, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Country Representative Main Menu";
            // 
            // hotelBookingBtn
            // 
            this.hotelBookingBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelBookingBtn.Location = new System.Drawing.Point(175, 238);
            this.hotelBookingBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hotelBookingBtn.Name = "hotelBookingBtn";
            this.hotelBookingBtn.Size = new System.Drawing.Size(394, 37);
            this.hotelBookingBtn.TabIndex = 22;
            this.hotelBookingBtn.Text = "Hotel Booking";
            this.hotelBookingBtn.UseVisualStyleBackColor = true;
            this.hotelBookingBtn.Click += new System.EventHandler(this.hotelBookingBtn_Click);
            // 
            // confirmArrivalBtn
            // 
            this.confirmArrivalBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmArrivalBtn.Location = new System.Drawing.Point(175, 196);
            this.confirmArrivalBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmArrivalBtn.Name = "confirmArrivalBtn";
            this.confirmArrivalBtn.Size = new System.Drawing.Size(394, 37);
            this.confirmArrivalBtn.TabIndex = 23;
            this.confirmArrivalBtn.Text = "Confirm Arrival Details";
            this.confirmArrivalBtn.UseVisualStyleBackColor = true;
            this.confirmArrivalBtn.Click += new System.EventHandler(this.confirmArrivalBtn_Click);
            // 
            // UpdateBookingBtn
            // 
            this.UpdateBookingBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBookingBtn.Location = new System.Drawing.Point(175, 280);
            this.UpdateBookingBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UpdateBookingBtn.Name = "UpdateBookingBtn";
            this.UpdateBookingBtn.Size = new System.Drawing.Size(394, 37);
            this.UpdateBookingBtn.TabIndex = 24;
            this.UpdateBookingBtn.Text = "Update Info / Booking";
            this.UpdateBookingBtn.UseVisualStyleBackColor = true;
            this.UpdateBookingBtn.Click += new System.EventHandler(this.UpdateBookingBtn_Click);
            // 
            // CountryRepMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 457);
            this.Controls.Add(this.UpdateBookingBtn);
            this.Controls.Add(this.confirmArrivalBtn);
            this.Controls.Add(this.hotelBookingBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CountryRepMainMenuForm";
            this.Text = "Country Representative Main Menu";
            this.Load += new System.EventHandler(this.CountryRepMainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hotelBookingBtn;
        private System.Windows.Forms.Button confirmArrivalBtn;
        private System.Windows.Forms.Button UpdateBookingBtn;
    }
}