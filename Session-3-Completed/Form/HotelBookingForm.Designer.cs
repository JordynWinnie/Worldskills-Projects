namespace Session3_Jordan_Khong
{
    partial class HotelBookingForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.lblNoOfPaxDelegates = new System.Windows.Forms.Label();
            this.numberofcompetitorsLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.roomInfoDGV = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.totalValueLbl = new System.Windows.Forms.Label();
            this.bookBtn = new System.Windows.Forms.Button();
            this.singleRoomErrorLbl = new System.Windows.Forms.Label();
            this.doubleRoomErrorLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomInfoDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(22, 25);
            this.backBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(121, 37);
            this.backBtn.TabIndex = 42;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.Red;
            this.timerLabel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(535, 511);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(48, 17);
            this.timerLabel.TabIndex = 41;
            this.timerLabel.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(497, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 40;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(0, 492);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(725, 52);
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 80);
            this.pictureBox1.TabIndex = 38;
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
            this.label2.Location = new System.Drawing.Point(272, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 43;
            this.label2.Text = "Hotel Booking";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "Hotel Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 45;
            this.label4.Text = "No. Of Pax:";
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblHotelName.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotelName.ForeColor = System.Drawing.Color.Black;
            this.lblHotelName.Location = new System.Drawing.Point(188, 132);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(132, 23);
            this.lblHotelName.TabIndex = 46;
            this.lblHotelName.Text = "(HotelName)";
            // 
            // lblNoOfPaxDelegates
            // 
            this.lblNoOfPaxDelegates.AutoSize = true;
            this.lblNoOfPaxDelegates.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblNoOfPaxDelegates.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPaxDelegates.ForeColor = System.Drawing.Color.Black;
            this.lblNoOfPaxDelegates.Location = new System.Drawing.Point(186, 163);
            this.lblNoOfPaxDelegates.Name = "lblNoOfPaxDelegates";
            this.lblNoOfPaxDelegates.Size = new System.Drawing.Size(170, 23);
            this.lblNoOfPaxDelegates.TabIndex = 47;
            this.lblNoOfPaxDelegates.Text = "(NoOfDelegates)";
            // 
            // numberofcompetitorsLbl
            // 
            this.numberofcompetitorsLbl.AutoSize = true;
            this.numberofcompetitorsLbl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numberofcompetitorsLbl.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberofcompetitorsLbl.ForeColor = System.Drawing.Color.Black;
            this.numberofcompetitorsLbl.Location = new System.Drawing.Point(186, 208);
            this.numberofcompetitorsLbl.Name = "numberofcompetitorsLbl";
            this.numberofcompetitorsLbl.Size = new System.Drawing.Size(192, 23);
            this.numberofcompetitorsLbl.TabIndex = 48;
            this.numberofcompetitorsLbl.Text = "(NoOfCompetitors)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(409, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 23);
            this.label6.TabIndex = 49;
            this.label6.Text = "Delegates (Excluding Head)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(409, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 23);
            this.label7.TabIndex = 50;
            this.label7.Text = "Competitors";
            // 
            // roomInfoDGV
            // 
            this.roomInfoDGV.AllowUserToAddRows = false;
            this.roomInfoDGV.AllowUserToDeleteRows = false;
            this.roomInfoDGV.AllowUserToOrderColumns = true;
            this.roomInfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomInfoDGV.Location = new System.Drawing.Point(9, 249);
            this.roomInfoDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.roomInfoDGV.Name = "roomInfoDGV";
            this.roomInfoDGV.RowHeadersWidth = 51;
            this.roomInfoDGV.RowTemplate.Height = 24;
            this.roomInfoDGV.Size = new System.Drawing.Size(709, 155);
            this.roomInfoDGV.TabIndex = 51;
            this.roomInfoDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomInfoDGV_CellEndEdit);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(527, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 23);
            this.label8.TabIndex = 52;
            this.label8.Text = "Total:";
            // 
            // totalValueLbl
            // 
            this.totalValueLbl.AutoSize = true;
            this.totalValueLbl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.totalValueLbl.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueLbl.ForeColor = System.Drawing.Color.Black;
            this.totalValueLbl.Location = new System.Drawing.Point(593, 419);
            this.totalValueLbl.Name = "totalValueLbl";
            this.totalValueLbl.Size = new System.Drawing.Size(126, 23);
            this.totalValueLbl.TabIndex = 53;
            this.totalValueLbl.Text = "(TotalValue)";
            // 
            // bookBtn
            // 
            this.bookBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookBtn.Location = new System.Drawing.Point(597, 449);
            this.bookBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(121, 37);
            this.bookBtn.TabIndex = 54;
            this.bookBtn.Text = "Book";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // singleRoomErrorLbl
            // 
            this.singleRoomErrorLbl.AutoSize = true;
            this.singleRoomErrorLbl.BackColor = System.Drawing.Color.Red;
            this.singleRoomErrorLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleRoomErrorLbl.Location = new System.Drawing.Point(9, 427);
            this.singleRoomErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.singleRoomErrorLbl.Name = "singleRoomErrorLbl";
            this.singleRoomErrorLbl.Size = new System.Drawing.Size(45, 14);
            this.singleRoomErrorLbl.TabIndex = 55;
            this.singleRoomErrorLbl.Text = "label5";
            this.singleRoomErrorLbl.Visible = false;
            // 
            // doubleRoomErrorLbl
            // 
            this.doubleRoomErrorLbl.AutoSize = true;
            this.doubleRoomErrorLbl.BackColor = System.Drawing.Color.Red;
            this.doubleRoomErrorLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doubleRoomErrorLbl.Location = new System.Drawing.Point(9, 460);
            this.doubleRoomErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doubleRoomErrorLbl.Name = "doubleRoomErrorLbl";
            this.doubleRoomErrorLbl.Size = new System.Drawing.Size(45, 14);
            this.doubleRoomErrorLbl.TabIndex = 56;
            this.doubleRoomErrorLbl.Text = "label5";
            this.doubleRoomErrorLbl.Visible = false;
            // 
            // HotelBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 547);
            this.Controls.Add(this.doubleRoomErrorLbl);
            this.Controls.Add(this.singleRoomErrorLbl);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.totalValueLbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.roomInfoDGV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberofcompetitorsLbl);
            this.Controls.Add(this.lblNoOfPaxDelegates);
            this.Controls.Add(this.lblHotelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HotelBookingForm";
            this.Text = "Hotel Booking";
            this.Load += new System.EventHandler(this.HotelBookingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomInfoDGV)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.Label lblNoOfPaxDelegates;
        private System.Windows.Forms.Label numberofcompetitorsLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView roomInfoDGV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label totalValueLbl;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Label singleRoomErrorLbl;
        private System.Windows.Forms.Label doubleRoomErrorLbl;
    }
}