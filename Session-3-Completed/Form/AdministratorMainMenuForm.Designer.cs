namespace Session3_Jordan_Khong
{
    partial class AdministratorMainMenuForm
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
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hotelSummarybtn = new System.Windows.Forms.Button();
            this.arrivalSummaryBtn = new System.Windows.Forms.Button();
            this.guestsSummaryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.Red;
            this.timerLabel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(536, 425);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(48, 17);
            this.timerLabel.TabIndex = 14;
            this.timerLabel.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(498, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(1, 406);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(725, 52);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 80);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(22, 25);
            this.backBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(121, 37);
            this.backBtn.TabIndex = 15;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(262, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 26);
            this.label2.TabIndex = 22;
            this.label2.Text = "Admin Main Menu";
            // 
            // hotelSummarybtn
            // 
            this.hotelSummarybtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelSummarybtn.Location = new System.Drawing.Point(22, 243);
            this.hotelSummarybtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hotelSummarybtn.Name = "hotelSummarybtn";
            this.hotelSummarybtn.Size = new System.Drawing.Size(692, 37);
            this.hotelSummarybtn.TabIndex = 23;
            this.hotelSummarybtn.Text = "Hotel Summary";
            this.hotelSummarybtn.UseVisualStyleBackColor = true;
            this.hotelSummarybtn.Click += new System.EventHandler(this.hotelSummarybtn_Click);
            // 
            // arrivalSummaryBtn
            // 
            this.arrivalSummaryBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalSummaryBtn.Location = new System.Drawing.Point(22, 201);
            this.arrivalSummaryBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.arrivalSummaryBtn.Name = "arrivalSummaryBtn";
            this.arrivalSummaryBtn.Size = new System.Drawing.Size(692, 37);
            this.arrivalSummaryBtn.TabIndex = 24;
            this.arrivalSummaryBtn.Text = "Arrival Summary";
            this.arrivalSummaryBtn.UseVisualStyleBackColor = true;
            this.arrivalSummaryBtn.Click += new System.EventHandler(this.arrivalSummaryBtn_Click);
            // 
            // guestsSummaryBtn
            // 
            this.guestsSummaryBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestsSummaryBtn.Location = new System.Drawing.Point(22, 285);
            this.guestsSummaryBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guestsSummaryBtn.Name = "guestsSummaryBtn";
            this.guestsSummaryBtn.Size = new System.Drawing.Size(692, 37);
            this.guestsSummaryBtn.TabIndex = 25;
            this.guestsSummaryBtn.Text = "Guests Summary";
            this.guestsSummaryBtn.UseVisualStyleBackColor = true;
            this.guestsSummaryBtn.Click += new System.EventHandler(this.guestsSummaryBtn_Click);
            // 
            // AdministratorMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 458);
            this.Controls.Add(this.guestsSummaryBtn);
            this.Controls.Add(this.arrivalSummaryBtn);
            this.Controls.Add(this.hotelSummarybtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdministratorMainMenuForm";
            this.Text = "Administrator Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hotelSummarybtn;
        private System.Windows.Forms.Button arrivalSummaryBtn;
        private System.Windows.Forms.Button guestsSummaryBtn;
    }
}